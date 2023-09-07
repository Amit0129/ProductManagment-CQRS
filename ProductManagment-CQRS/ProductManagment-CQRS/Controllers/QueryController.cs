using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductManagment_CQRS.Entity;
using ProductManagment_CQRS.Interface;
using ProductManagment_CQRS.Model.Query;

namespace ProductManagment_CQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        public readonly IQueryService queryService;
        public QueryController(IQueryService queryService)
        {
            this.queryService = queryService;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var products = queryService.GetAll();
                if (products == null)
                {
                    return BadRequest(new { sucess = false, message = "Retrive Products Failed" });
                }
                return Ok(new { sucess = true, message = "Retrive Product Sucessfull", data = products });
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpGet("GetById/{id}")]
        public IActionResult GetProductById(int id)
        {
            try
            {
                var product = queryService.GetProductById(id);
                if (product == null)
                {
                    return BadRequest(new { sucess = false, message = "Retrive Products Failed" });
                }
                return Ok(new { sucess = true, message = "Retrive Product Sucessfull", data = product });
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
