using Presentation.Data;
using Presentation.Interfaces;

namespace Presentation.Services;

public class ClientService : IClientService
{
    private const string CustomerApi = "api/Customers";
    private const string EmployeesApi = "api/Employees";

    private readonly HttpClient _httpClient;
    private readonly ILogger<ClientService> _logger;

    public ClientService(HttpClient httpClient, ILogger<ClientService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<List<CustomerModel>> GetCustomers()
    {
        var customers = new List<CustomerModel>();

        try
        {
            var response = await _httpClient.GetAsync(CustomerApi);

            if (response.IsSuccessStatusCode)
            {
                customers = await response.Content.ReadFromJsonAsync<List<CustomerModel>>();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return customers;
    }

    public async Task<List<EmployeeModel>> GetEmployees()
    {
        var employees = new List<EmployeeModel>();

        try
        {
            var response = await _httpClient.GetAsync(EmployeesApi);

            if (response.IsSuccessStatusCode)
            {
                employees = await response.Content.ReadFromJsonAsync<List<EmployeeModel>>();
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
        }

        return employees;
    }
}
