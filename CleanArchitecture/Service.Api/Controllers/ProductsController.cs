using Application.Products.Queries.GetListProduct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Service.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetProduct()
    {
        var products = await _mediator.Send(new GetListProductQuery());

        return Ok(products ?? new List<ProductModel>());
    }
}