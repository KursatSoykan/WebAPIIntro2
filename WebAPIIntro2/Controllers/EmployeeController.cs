using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIIntro2.Models;

namespace WebAPIIntro2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        NorthwndContext db = new NorthwndContext();

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Employee> employee = db.Employees.ToList();
            return Ok(employee);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id) 
        { 
            if (id == 0)
            { 
                NotFound("Boyle bir Id bulunamadi");
            }
            Employee employee = db.Employees.FirstOrDefault(x => x.EmployeeId == id);
            return Ok(employee);
        }
    }
}
