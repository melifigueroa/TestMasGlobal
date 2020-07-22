using Domain.Aggregates;
using Domain.Repositories;
using Employees.Infraestructure.Config;
using Infraestucture.HttpClients;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infraestucture.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeHttpClient _employeeHttpClient;
        private readonly EmployeeClientConfig _employeeClientConfig;

        public EmployeeRepository(EmployeeHttpClient employeeHttpClient)
        {
            _employeeHttpClient = employeeHttpClient;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var uri = new Uri("http://masglobaltestapi.azurewebsites.net/api/Employees");
            return await _employeeHttpClient.GetAsync<IEnumerable<Employee>>(uri);
        }
    }
}
