using Azure.Core;
using FashionStock.Data;
using FashionStock.Entities;
using FashionStock.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FashionStock.WebApi.Models;
using System.Collections;
using Microsoft.AspNetCore.Http.HttpResults;

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
            var categoryTable = await _businessContext.Categories.ToListAsync();

            if (!categoryTable.Any())

                return NotFound();
            else

                return Ok(categoryTable);
        }

        [HttpPost("/addcategories")]

        public async Task<IActionResult> AddCategory([FromBody]CategoryModel categorymodel)
        {
            var category = await _businessContext.Categories.FirstOrDefaultAsync(c => c.Id.Equals(categorymodel.Id));

            if (category is not null) 
                return BadRequest();

                var newCategory = new Category();
                newCategory.Name = categorymodel.Name;
                newCategory.Description = categorymodel.Description;
                newCategory.CreatedAt = DateTime.Now;
                newCategory.UpdatedAt = DateTime.Now;

                _businessContext.Categories.Add(newCategory);
                
                
                    var result = await _businessContext.SaveChangesAsync();
                    if (result.Equals(1))
                        return Ok();
              

                return BadRequest();
                    
        }
    }
}
