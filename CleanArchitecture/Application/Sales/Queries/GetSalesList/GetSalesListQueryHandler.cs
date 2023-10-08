using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Sales.Queries.GetSalesList;

public class GetSalesListQueryHandler : IRequestHandler<GetSalesListQuery, List<SaleItemModel>>
{
    public ApplicationDbContext _dbContext;

    public GetSalesListQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<SaleItemModel>> Handle(GetSalesListQuery request, CancellationToken cancellationToken)
    {
        return await _dbContext.Sales
                        .Select(p => new SaleItemModel()
                        {
                            Id = p.Id,
                            Date = p.Date,
                            CustomerName = p.Customer.Name,
                            EmployeeName = p.Employee.Name,
                            ProductName = p.Product.Name,
                            UnitPrice = p.UnitPrice,
                            Quantity = p.Quantity,
                            TotalPrice = p.TotalPrice
                        }).AsNoTracking().ToListAsync(cancellationToken);
    }
}