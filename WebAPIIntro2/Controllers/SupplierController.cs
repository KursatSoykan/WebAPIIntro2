using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIIntro2.Models;

namespace WebAPIIntro2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        NorthwndContext db = new NorthwndContext();

        [HttpGet]
        public IActionResult GetAll() 
        {
            List<Supplier> suppliers =db.Suppliers.ToList();
            return Ok(suppliers);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (id == 0)
                return BadRequest();
            Supplier supplier =db.Suppliers.FirstOrDefault(x => x.SupplierId == id);
            return Ok(supplier);
        }

    }
}
