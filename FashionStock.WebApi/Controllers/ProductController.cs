using Azure.Core;
using FashionStock.Data;
using FashionStock.Entities;
using FashionStock.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;

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
            var productTable = await _businessContext.Products.Where(p => p.IsDeleted == false).ToListAsync();

            if (!productTable.Any())

                return NotFound();
            else

                return Ok(productTable);
        }


       
        [HttpDelete("/deleteproducts")]

        public async Task<IActionResult> DeleteProduct(long id)
        {
            var product = await _businessContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(id));

            if (product is null)
                return BadRequest();

            product.IsDeleted = true;

            var result = await _businessContext.SaveChangesAsync();
            if (result.Equals(1))
                return Ok();

            return BadRequest();
        }

        [HttpPost("/addproduct")]
        public async Task<IActionResult> AddProduct(ProductModel productmodel)
        {
            var product = await _businessContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(productmodel.Id));

            if (product is not null)

                return BadRequest();

            var newproduct = new Product();
            newproduct.Name = productmodel.Name;
            newproduct.Description = productmodel.Description;  
            newproduct.Price = productmodel.Price;
            newproduct.CategoryId = productmodel.CategoryId;
            newproduct.Quantity = productmodel.Quantity;
            newproduct.CreatedAt = DateTime.Now;
            newproduct.UpdatedAt = DateTime.Now;


            _businessContext.Products.Add(newproduct);

            try
            {
                var result = await _businessContext.SaveChangesAsync();
                if (result.Equals(1))
                    return Ok();

            }
            catch (Exception)
            {

                throw;
            }

               return BadRequest(); 

        }

        [HttpGet("/getproduct")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var productTable = await _businessContext.Products.FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id.Equals(id));
            if (productTable is null)
                return NotFound();
            else
                return Ok(productTable);
        }

        [HttpPut("/updateproduct")]
        public async Task<IActionResult> UpdateProduct(ProductModel productmodel)
        {
            var product = await _businessContext.Products.FirstOrDefaultAsync(p => p.Id.Equals(productmodel.Id));

            if (product is null)

                return BadRequest();

            product.Name = productmodel.Name;
            product.Description = productmodel.Description;
            product.Price = productmodel.Price;
            product.CategoryId = productmodel.CategoryId;
            product.Quantity = productmodel.Quantity;
            product.UpdatedAt = DateTime.Now;


            try
            {
                var result = await _businessContext.SaveChangesAsync();
                if (result.Equals(1))
                    return Ok();

            }
            catch (Exception)
            {

                throw;
            }

            return BadRequest();

        }


    }
}
