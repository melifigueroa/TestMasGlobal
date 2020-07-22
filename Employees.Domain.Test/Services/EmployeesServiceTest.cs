using Domain.Aggregates;
using Domain.Repositories;
using Domain.Services;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Employees.Domain.Test.Services
{
    public class EmployeesServiceTest
    {
        private readonly EmployeeService _employeesService;
        private readonly Mock<IEmployeeRepository> _employeeRepository;

        public EmployeesServiceTest()
        {
            _employeeRepository = new Mock<IEmployeeRepository>();

            _employeesService = new EmployeeService(_employeeRepository.Object);
        }

        [Fact]
        public async Task GetAllTest()
        {
            // Arrange
            _employeeRepository
               .Setup(er => er.GetAllAsync())
               .ReturnsAsync(new List<Employee>
               {
                    new Employee("Melissa", "HourlySalaryEmployee", 1, "Administrator", null, 60000, 80000)
               });

            // Act
            var employees = await _employeesService.GetAllAsync();

            // Assert
            var employee = employees.First();
            employee.AnnualSalary
                .Should()
                .Be(86400000);
        }
    }
}
