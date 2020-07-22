namespace Domain.Services
{
    public abstract class EmployeeAnnualSalaryService
    {
        private const int months = 12;
        protected float _salary;

        public EmployeeAnnualSalaryService(float salary)
        {
            _salary = salary;
        }

        public virtual double AnnualSalary() => _salary * months;
    }
}
