#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Service.Api/Service.Api.csproj", "Service.Api/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Persistence/Persistence.csproj", "Persistence/"]
COPY ["Domain/Domain.csproj", "Domain/"]
RUN dotnet restore "Service.Api/Service.Api.csproj"
COPY . .
WORKDIR "/src/Service.Api"
RUN dotnet build "Service.Api.csproj" -c Release -o /app/buildapp

FROM build AS publish
RUN dotnet publish "Service.Api.csproj" -c Release -o /app/publishapp /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publishapp .
ENTRYPOINT ["dotnet", "Service.Api.dll"]