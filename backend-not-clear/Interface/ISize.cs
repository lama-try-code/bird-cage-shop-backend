using backend_not_clear.DTO.SizeDTO.CreateForCustom;
using backend_not_clear.DTO.SizeDTO.CreateSize;
using backend_not_clear.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Interface
{
    public interface ISize
    {
        Task<List<Size>> GetAll();
        Task<List<Size>> GetForSort();
        Task<Size> CreateSize(CreateSize size);
        Task<Size> GetById(string SizeId);
        Task<List<Size>> GetByName(string SizeName);
        Task<List<Size>> GetByStyle(string styleId);
        Task<IEnumerable<string>> GetUniqueSizeNames(string styleId);
    }
}
