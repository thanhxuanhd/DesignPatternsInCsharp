using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Customer.Queries.GetCustomers;

public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, List<CustomerModel>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetCustomerListQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<CustomerModel>> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Customers
                 .Select(p => new CustomerModel()
                 {
                     Id = p.Id,
                     Name = p.Name
                 }).AsNoTracking().ToListAsync(cancellationToken);
    }
}