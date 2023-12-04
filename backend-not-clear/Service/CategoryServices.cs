using backend_not_clear.DTO.CategoryDTO.CreateCategory;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Service
{
    public class CategoryServices : ICategory
    {
        private readonly BCS_ShopContext _context;
        public CategoryServices(BCS_ShopContext context)
        {
            _context = context;
        }
        public async Task<Category> CreateCategory(CreateCategory category)
        {
            try
            {
                var add = new Category();
                add.CategoryId = "Cate" + Guid.NewGuid().ToString().Substring(0, 5);
                add.CategoryName = category.CategoryName;
                add.Description = category.CategoryDescription;
                add.Type = category.Type;
                await this._context.Category.AddAsync(add);
                await this._context.SaveChangesAsync();
                return add;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<List<Category>> GetAll()
        {
            try
            {
                var list = await this._context.Category
                    .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
