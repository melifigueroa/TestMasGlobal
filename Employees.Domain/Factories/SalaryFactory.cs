using Domain.Aggregates;
using Domain.Services;
using System;
using TestMasGlobal.Models.Enum;

namespace Domain.Factories
{
    public static class SalaryFactory
    {
        public static EmployeeAnnualSalaryService GetSalary(Employee employee)
        {
            switch (employee.SalaryType)
            {
                case SalaryType.MonthlySalaryEmployee:
                    return new MonthlySalaryService(employee.MonthlySalary);
                case SalaryType.HourlySalaryEmployee:
                    return new HourlySalaryService(employee.HourlySalary);
                default:
                    throw new InvalidOperationException("Contract type not found");
            }
        }
    }
}
