using backend_not_clear.DTO.ColorDTO.CreateColor;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Service
{
    public class ColorServices : IColor
    {
        private readonly BCS_ShopContext _context;
        public ColorServices(BCS_ShopContext context)
        {
            _context = context;
        }

        public async Task<Color> CreateNewColor(CreateColor color)
        {
            try
            {
                var add = new Color();
                add.ColorId = "CO" + Guid.NewGuid().ToString().Substring(0, 7);
                add.ColorName = color.ColorName;
                add.MaterialId = color.MaterialID;
                add.IsCustom = color.IsCustom;
                add.Price = color.Price;
                await this._context.Color.AddAsync(add);
                await this._context.SaveChangesAsync();
                return add;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Color>> GetAll()
        {
            try
            {
                var list = await this._context.Color
                    .Where(x => !x.IsCustom)
                    .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Color>> GetByMaterial()
        {
            try
            {
                var list = await this._context.Color.Where(x => x.IsCustom).ToListAsync();
                if (list != null)
                    return list;
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Color> GetById(string id)
        {
            try
            {
                var color = await this._context.Color.Where(x => x.ColorId.Equals(id)).FirstOrDefaultAsync();
                if (color != null)
                    return color;
                return null;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
