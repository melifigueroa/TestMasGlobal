using System.Threading.Tasks;
using Employees.Application.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Employees.Web.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeesQueries _employeesQueries;

        public EmployeesController(EmployeesQueries employeesQueries)
        {
            _employeesQueries = employeesQueries;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _employeesQueries.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            return Ok(await _employeesQueries.GetByIdAsync(id));
        }
    }
}
