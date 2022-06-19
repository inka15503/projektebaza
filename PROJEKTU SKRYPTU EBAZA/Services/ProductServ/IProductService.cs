using Microsoft.AspNetCore.Http;
using PROJEKTU_SKRYPTU_EBAZA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJEKTU_SKRYPTU_EBAZA.Services.ProductServ
{
    public interface IProductService
    {
        public Task<List<Product>> GetProductsAsync();
        public Task<List<Product>> GetProductsFromSupplierAsync(int id);
        public Task<Product> AddProductAsync(Product product, IFormFile file);
        public Task<Product> EditProductAsync(Product product);

        public Task<bool> RemoveProductAsync(int productId);
        public Task<Product> GetProductAsync(int id);
        public Task<List<Product>> GerProductsFromCategoryAsync(int categoryid);
    }
}
