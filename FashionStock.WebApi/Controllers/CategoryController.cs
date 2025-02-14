using FashionStock.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly BusinessContext _businessContext;

        public CategoryController (BusinessContext businessContext)
        {
            _businessContext = businessContext;
        }

        [HttpGet("/getcategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categoryTable = await _businessContext.Categories.Where(c => c.IsDeleted == false).ToListAsync();

            if (!categoryTable.Any())

                return Ok(categoryTable);
            else

                return Ok(categoryTable);
        }
    }
}
