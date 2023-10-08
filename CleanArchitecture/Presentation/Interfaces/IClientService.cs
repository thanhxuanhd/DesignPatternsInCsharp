using Presentation.Data;

namespace Presentation.Interfaces;

public interface IClientService
{
    Task<List<CustomerModel>> GetCustomers();

    Task<List<EmployeeModel>> GetEmployees();
}
