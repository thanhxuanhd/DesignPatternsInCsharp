using Application.Customer.Queries.GetCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Service.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly IMediator _mediator;

    public CustomersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet(Name = "GetCustomers")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCustomers()
    {
        var customers = await _mediator.Send(new GetCustomerListQuery());
        return Ok(customers ?? new List<CustomerModel>());
    }
}