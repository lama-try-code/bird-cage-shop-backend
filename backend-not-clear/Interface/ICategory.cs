using backend_not_clear.DTO.CategoryDTO.CreateCategory;
using backend_not_clear.Models;

namespace backend_not_clear.Interface
{
    public interface ICategory
    {
        Task<List<Category>> GetAll();
        Task<Category> CreateCategory(CreateCategory category);
    }
}
