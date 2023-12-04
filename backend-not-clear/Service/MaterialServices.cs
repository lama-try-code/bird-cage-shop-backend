using backend_not_clear.DTO.MaterialDTO.CreateMaterial;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace backend_not_clear.Service
{
    public class MaterialServices : IMaterial
    { 
        private readonly BCS_ShopContext _context;
        public MaterialServices(BCS_ShopContext context)
        {
            this._context = context;
        }

        public async Task<List<Material>> GetAll()
        {
            try
            {
                var list = await this._context.Material.Where(x => !x.IsCustom).ToListAsync();
                if (list == null)
                    return null;
                return list;
            } catch(Exception ex)
            {   
                throw new Exception(ex.Message);
            }
        }

        public async Task<Material> GetById(string materialId)
        {
            try
            {
                var material = await this._context.Material.Where(x => x.MaterialId.Equals(materialId))
                                                           .FirstOrDefaultAsync();
                if (material != null)
                    return material;
                return null;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Material>> GetBySize(string SizeId)
        {
            try
            {
                var list = await this._context.Material.Where(x => x.SizeId.Equals(SizeId) && x.IsCustom)
                                                       .Include(x => x.Image)
                                                       .ToListAsync();
                if (list != null)
                    return list;
                return null;
            } catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
