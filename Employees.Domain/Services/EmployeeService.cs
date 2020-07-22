using Domain.Aggregates;
using Domain.Factories;
using Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> GetAllAsync()
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.Select(employee =>
            {
                employee.AnnualSalary = SalaryFactory.GetSalary(employee).AnnualSalary();
                return employee;
            });
        }

        public async Task<IEnumerable<Employee>> GetByIdAsync(int id)
        {
            var employees = await _employeeRepository.GetAllAsync();
            return employees.Where((employee) => employee.Id == id).Select(employee =>
            {
                employee.AnnualSalary = SalaryFactory.GetSalary(employee).AnnualSalary();
                return employee;
            });
        }
    }
}
