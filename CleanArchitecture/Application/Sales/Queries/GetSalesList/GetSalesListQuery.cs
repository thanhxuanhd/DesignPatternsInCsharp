using MediatR;

namespace Application.Sales.Queries.GetSalesList;

public class GetSalesListQuery : IRequest<List<SaleItemModel>>
{
}
