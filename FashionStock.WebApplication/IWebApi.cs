using FashionStock.WebApi.Models;
using Refit;
namespace FashionStock.WebApplication
{
    public interface IWebApi
    {
        [Get("/getproducts")]
        Task<List<ProductModel>> GetProducts();
    }
}
