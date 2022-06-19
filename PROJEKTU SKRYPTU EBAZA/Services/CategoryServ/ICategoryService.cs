using PROJEKTU_SKRYPTU_EBAZA.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJEKTU_SKRYPTU_EBAZA.Services.CategoryServ
{
    public interface ICategoryService
    {
      public Task<List<ProductCategory>> GetCategoriesAsync();
        public Task<ProductCategory> GetCategoryAsync(int categoryid);
        public Task<ProductCategory> AddCategoryAsync(ProductCategory model);
        public Task<ProductCategory> EditCategoryAsync(ProductCategory model);
        public Task<bool> RemoveCategoryAsync(int productId);

    }
}
