using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagment_CQRS.Interface;
using ProductManagment_CQRS.Model.Command;

namespace ProductManagment_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommandService commandService;
        public CommandController(ICommandService commandService)
        {
              this.commandService = commandService;
        }
        [HttpPost]
        public IActionResult AddProduct(InsertUpdateModel newProduct)
        {
            try
            {
                var product = commandService.AddProduct(newProduct);
                if (product == 1)
                {
                    return Ok(new {sucess =true,message = "Data Added Sucessfull"});
                }
                return BadRequest(new { sucess = false, message = "Data Added Failed" });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPut("Update/{id}")]
        public IActionResult UpdateProduct(InsertUpdateModel newProduct, int id)
        {
            try
            {
                var product = commandService.UpdateProduct(newProduct, id);
                if (product)
                {
                    return Ok(new { sucess = true, message = "Data Update Sucessfull" });
                }
                return BadRequest(new { sucess = false, message = "Data Update Failed" });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
