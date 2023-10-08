using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products.Queries.GetListProduct;

public class GetListProductQueryHandler : IRequestHandler<GetListProductQuery, List<ProductModel>>
{
    private readonly ApplicationDbContext _dbContext;

    public GetListProductQueryHandler(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public Task<List<ProductModel>> Handle(GetListProductQuery request, CancellationToken cancellationToken)
    {
        return _dbContext.Products
                 .Select(p => new ProductModel
                 {
                     Id = p.Id,
                     Name = p.Name,
                     UnitPrice = p.Price
                 }).AsNoTracking().ToListAsync(cancellationToken);
    }
}