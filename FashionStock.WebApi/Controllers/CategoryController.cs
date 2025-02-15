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

        public CategoryController(BusinessContext businessContext)
        {
            _businessContext = businessContext;
        }

        [HttpGet("/getcategories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _businessContext.Categories.Where(c => c.IsDeleted == false).ToListAsync();
            if (!categories.Any())
                return NotFound();
            else
                return Ok(categories);
        }

        [HttpGet("/getcategory")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var categories = await _businessContext.Categories.FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id.Equals(id));
            if (categories is null)
                return NotFound();
            else
                return Ok(categories);
        }

    }
}
