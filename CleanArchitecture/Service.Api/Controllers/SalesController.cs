using Application.Sales.Queries.GetSaleDetail;
using Application.Sales.Queries.GetSalesList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Service.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SalesController : ControllerBase
{
    private readonly IMediator _mediator;

    public SalesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var sales = await _mediator.Send(new GetSalesListQuery());
        return Ok(sales ?? new List<SaleItemModel>());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var sale = await _mediator.Send(new GetSaleDetailQuery()
        {
            SaleId = id
        });
        if (sale is null)
        {
            return BadRequest(id);
        }

        return Ok(sale);
    }
}