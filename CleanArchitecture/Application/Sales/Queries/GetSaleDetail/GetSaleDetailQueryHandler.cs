using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Sales.Queries.GetSaleDetail;

public class GetSaleDetailQueryHandler : IRequestHandler<GetSaleDetailQuery, SaleDetailModel>
{
    private readonly ApplicationDbContext _dbContext;

    public GetSaleDetailQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<SaleDetailModel> Handle(GetSaleDetailQuery request, CancellationToken cancellationToken)
    {
        var sale = await _dbContext.Sales
                .FirstOrDefaultAsync(p => p.Id == request.SaleId, cancellationToken);

        return sale is not null ? new SaleDetailModel()
        {
            Id = sale.Id,
            Date = sale.Date,
            CustomerName = sale.Customer.Name,
            EmployeeName = sale.Employee.Name,
            ProductName = sale.Product.Name,
            UnitPrice = sale.UnitPrice,
            Quantity = sale.Quantity,
            TotalPrice = sale.TotalPrice
        } : new SaleDetailModel();
    }
}