using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Employees.Queries.GetEmployees
{
    internal class GetEmployeesListQueryHandler : IRequestHandler<GetEmployeesListQuery, List<EmployeeModel>>
    {
        private readonly ApplicationDbContext _dbContext;

        public GetEmployeesListQueryHandler(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<EmployeeModel>> Handle(GetEmployeesListQuery request, CancellationToken cancellationToken)
        {
            return await _dbContext.Employees
                  .Select(p => new EmployeeModel
                  {
                      Id = p.Id,
                      Name = p.Name
                  }).AsNoTracking().ToListAsync(cancellationToken);
        }
    }
}