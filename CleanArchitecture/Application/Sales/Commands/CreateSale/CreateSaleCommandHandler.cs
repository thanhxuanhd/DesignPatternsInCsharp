using MediatR;
using Persistence;

namespace Application.Sales.Commands.CreateSale
{
    internal class CreateSaleCommandHandler : IRequestHandler<CreateSaleCommand, int>
    {
        private readonly ApplicationDbContext _dbContext;

        public CreateSaleCommandHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var customer = _dbContext.Customers
                .Single(p => p.Id == request.CustomerId);

            var employee = _dbContext.Employees
                .Single(p => p.Id == request.EmployeeId);

            var product = _dbContext.Products
                .Single(p => p.Id == request.ProductId);

            var sale = new Domain.Models.Sale()
            {
                Quantity = request.Quantity,
                Customer = customer,
                Date = DateTime.UtcNow,
                Employee = employee,
                Product = product
            };

            await _dbContext.Sales.AddAsync(sale, cancellationToken);

            return sale.Id;
        }
    }
}