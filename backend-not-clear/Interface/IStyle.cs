using backend_not_clear.DTO.StyleDTO.CreateStyle;
using backend_not_clear.DTO.StyleDTO.SearchStyle;
using backend_not_clear.DTO.StyleDTO.UpdateStyle;
using backend_not_clear.Models;

namespace backend_not_clear.Interface
{
    public interface IStyle
    {
        //does not need to create custom
        //when choose, id pass to create size for store custom
        Task<List<Style>> GetAll();
        Task<List<Style>> GetForSort();
        Task<List<Style>> GetByCustom();
        Task<Style> GetById(string id);
        Task<Style> CreateStyle(CreateStyle styleId);
        Task<Style> DeleteStyle(string StyleID);
    }
}
