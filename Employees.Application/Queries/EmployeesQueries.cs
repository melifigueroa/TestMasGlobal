using Domain.Aggregates;
using Domain.Services;
using Employees.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employees.Application.Queries
{
    public class EmployeesQueries
    {
        private readonly EmployeeService _employeeService;

        public EmployeesQueries(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetAllAsync()
        {
            return (await _employeeService.GetAllAsync()).Select(employee => new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                RoleId = employee.RoleId,
                RoleName = employee.RoleName,
                RoleDescription = employee.RoleDescription,
                HourlySalary = employee.HourlySalary,
                MonthlySalary = employee.MonthlySalary,
                AnnualSalary = employee.AnnualSalary,
                ContractTypeName = employee.ContractTypeName
            });
        }

        public async Task<IEnumerable<EmployeeViewModel>> GetByIdAsync(int id)
        {
            return (await _employeeService.GetByIdAsync(id)).Select(employee => new EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                RoleId = employee.RoleId,
                RoleName = employee.RoleName,
                RoleDescription = employee.RoleDescription,
                HourlySalary = employee.HourlySalary,
                MonthlySalary = employee.MonthlySalary,
                AnnualSalary = employee.AnnualSalary,
                ContractTypeName = employee.ContractTypeName
            });
        }

    }
}
