using Azure.Core;
using FashionStock.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly BusinessContext _businessContext;

        public ProductController(BusinessContext businessContext)
        {
            _businessContext = businessContext;
        }

        [HttpGet("/getproducts")]
        public async Task<IActionResult> GetProducts()
        {
            var productTable = await _businessContext.Products.ToListAsync();

            if (!productTable.Any())
            
                return NotFound();
            else

            return Ok(productTable);
        }
    }
}
