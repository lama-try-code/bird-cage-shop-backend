using backend_not_clear.DTO.MaterialDTO.CreateMaterial;
using backend_not_clear.Models;

namespace backend_not_clear.Interface
{
    public interface IMaterial
    {
        Task<List<Material>> GetAll();
        Task<Material> GetById(string materialId);
        Task<List<Material>> GetBySize(string SizeId);
    }
}
