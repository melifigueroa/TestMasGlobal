﻿namespace Employees.Application.ViewModels
{
    public class EmployeeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ContractTypeName { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; }

        public float HourlySalary { get; set; }

        public float MonthlySalary { get; set; }

        public double AnnualSalary { get; set; }
    }
}
