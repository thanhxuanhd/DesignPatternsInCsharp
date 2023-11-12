using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Monolith.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<Repository>();
builder.Services.AddControllers();
builder.Services.AddHealthChecks();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "BookService.API", Version = "v1" });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Discount.API v1"));
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapHealthChecks("/hc");

app.MapControllers();

app.Run();