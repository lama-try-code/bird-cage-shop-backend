using backend_not_clear.DTO.ColorDTO.CreateColor;
using backend_not_clear.Models;

namespace backend_not_clear.Interface
{
    public interface IColor
    {
        Task<List<Color>> GetAll();
        Task<List<Color>> GetByMaterial();
        Task<Color> CreateNewColor(CreateColor color);
        Task<Color> GetById(string id);
    }
}
