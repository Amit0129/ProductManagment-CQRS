using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagment_CQRS.Interface;
using ProductManagment_CQRS.Model.Command;

namespace ProductManagment_CQRS.Controllers
{
    /// <summary>
    /// Product Command Side Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class CommandController : ControllerBase
    {
        private readonly ICommandService commandService;
        public CommandController(ICommandService commandService)
        {
              this.commandService = commandService;
        }
        /// <summary>
        /// Resister product Controller endpoint
        /// </summary>
        /// <param name="newProduct">New Product Model</param>
        /// <returns>SMD Format</returns>
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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        /// <summary>
        /// Update product by id Controller endpoint
        /// </summary>
        /// <param name="newProduct">New Product Model</param>
        /// <param name="id">An Exition product Id</param>
        /// <returns>SMD Format</returns>
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
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}
