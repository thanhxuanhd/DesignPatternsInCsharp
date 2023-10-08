using MediatR;

namespace Application.Sales.Queries.GetSaleDetail
{
    public class GetSaleDetailQuery : IRequest<SaleDetailModel>
    {
        public int SaleId { get; set; }
    }
}
