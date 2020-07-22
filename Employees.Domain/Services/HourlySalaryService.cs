namespace Domain.Services
{
    public class HourlySalaryService : EmployeeAnnualSalaryService
    {
        private const int Factor = 120;

        public HourlySalaryService(float hourlySalary) : base(hourlySalary)
        {
            
        }

        public override double AnnualSalary() => Factor * base.AnnualSalary() ;
    }
}
