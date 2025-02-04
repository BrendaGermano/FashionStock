using Azure.Core;
using FashionStock.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Refit;
namespace FashionStock.WebApplication
{
    public interface IWebApi
    {
        [Get("/getproducts")]
        Task<List<ProductModel>> GetProducts();

        [Get("/getproduct")]
        Task<WebApi.Models.ProductModel> GetProduct(int id);

    }
}
