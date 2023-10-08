using MediatR;

namespace Application.Sales.Commands.CreateSale
{
    public class CreateSaleCommand : IRequest<int>
    {
        public int CustomerId { get; set; }

        public int EmployeeId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
