using MediatR;

namespace Application.Customer.Queries.GetCustomers
{
    public class GetCustomerListQuery : IRequest<List<CustomerModel>>
    {
    }
}
