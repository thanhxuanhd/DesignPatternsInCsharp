using MediatR;

namespace Application.Employees.Queries.GetEmployees
{
    public class GetEmployeesListQuery : IRequest<List<EmployeeModel>>
    {
    }
}