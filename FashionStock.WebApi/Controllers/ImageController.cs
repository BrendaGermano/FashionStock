using FashionStock.Data;
using FashionStock.Entities;
using FashionStock.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FashionStock.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly BusinessContext _businessContext;

        public ImageController(BusinessContext businessContext)
        {
            _businessContext = businessContext;
        }

        [HttpPost("/addimage")]
        public async Task<IActionResult> AddImage(ImageModel imagemodel)
        {
            var image = await _businessContext.Images.FirstOrDefaultAsync(i => i.Id.Equals(imagemodel.Id));

            if (image is not null)

                return BadRequest();

            var newimage = new Image();
            newimage.Name = imagemodel.Name;
            newimage.Url = imagemodel.Url;
            newimage.ProductId = imagemodel.ProductId;
            newimage.CreatedAt = DateTime.Now;
            newimage.UpdatedAt = DateTime.Now;


            _businessContext.Images.Add(newimage);

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

        [HttpGet("/getimages")]
        public async Task<IActionResult> GetImages()
        {
            var imageTable = await _businessContext.Images.Where(i => i.IsDeleted == false).ToListAsync();

            if (!imageTable.Any())

                return Ok(imageTable);
            else

                return Ok(imageTable);
        }

        [HttpDelete("/deleteimage")]
        public async Task<IActionResult> DeleteImage(long id)
        {
            var image = await _businessContext.Images.FirstOrDefaultAsync(i => i.Id.Equals(id));

            if (image is null)
                return BadRequest();

            image.IsDeleted = true;

            var result = await _businessContext.SaveChangesAsync();
            if (result.Equals(1))
                return Ok();

            return BadRequest();
        }

    }
}
