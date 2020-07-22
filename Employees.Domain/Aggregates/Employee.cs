using System;
using TestMasGlobal.Models.Enum;

namespace Domain.Aggregates
{
    public class Employee
    {
        public Employee(string name, string contractTypeName, int roleId, string roleName, string roleDescription, float hourlySalary, float monthlySalary)
        {
            Name = name ?? throw new ArgumentNullException(nameof(Name));
            ContractTypeName = contractTypeName ?? throw new ArgumentNullException(nameof(ContractTypeName));
            if (!Enum.IsDefined(typeof(SalaryType), contractTypeName))
            {
                throw new InvalidOperationException("Contract Type Name not valid");
            }
            RoleId = roleId;
            RoleName = roleName ?? throw new ArgumentNullException(nameof(RoleName));
            RoleDescription = roleDescription;
            HourlySalary = hourlySalary;
            MonthlySalary = monthlySalary;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string ContractTypeName { get; set; }

        public int RoleId { get; set; }

        public string RoleName { get; set; }

        public string RoleDescription { get; set; } 

        public float HourlySalary { get; set; }

        public float MonthlySalary { get; set; }

        public double AnnualSalary { get; set; }

        public SalaryType SalaryType => (SalaryType)Enum.Parse(typeof(SalaryType), ContractTypeName);
    }
}
