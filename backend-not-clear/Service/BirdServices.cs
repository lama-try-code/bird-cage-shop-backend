using backend_not_clear.DTO.BirdDTO.BirdCreate;
using backend_not_clear.DTO.BirdDTO.UpdateBird;
using backend_not_clear.Interface;
using backend_not_clear.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_not_clear.Service
{
    public class BirdServices : IBird
    {
        private readonly BCS_ShopContext _context;

        public BirdServices(BCS_ShopContext context)
        {
            _context = context;
        }

        public async Task<List<Bird>> GetForSort()
        {
            try
            {
                var list = await this._context.Bird
                            .Where(x => x.Status)
                            .Include(x => x.BirdTypeNavigation)
                            .Include(x => x.Image)
                            .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Bird>> GetAll()
        {
            try
            {
                var list = await this._context.Bird
                            .Include(x => x.BirdTypeNavigation)
                            .Include(x => x.Image)
                            .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Bird>> SearchByName(string name)
        {
            try
            {
                var list = await this._context.Bird
                            .Where(x => x.BirdName.Contains(name))
                            .ToListAsync();
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Bird> CreateBird(CreateBird bird)
        {
            try
            {
                var add = new Bird();
                add.BirdId = "B" + Guid.NewGuid().ToString().Substring(0, 8);
                add.BirdName = bird.BirdName;
                add.Description = bird.Description;
                add.BirdSize = bird.SizesID;
                add.BirdType = bird.TypesID;
                add.Status = true;
                await this._context.Bird.AddAsync(add);
                await this._context.SaveChangesAsync();
                return add;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Bird> UpdateBird(UpdateBird bird)
        {
            try
            {
                var update = await this._context.Bird.Where(x => x.BirdId.Equals(bird.BirdID))
                                .FirstOrDefaultAsync();
                if (update != null)
                {
                    update.BirdName = bird.BirdName;
                    update.Description = bird.BirdDescription;
                    update.BirdType = update.BirdType ?? bird.BirdTypes;
                    update.BirdSize = update.BirdSize ?? bird.BirdSizes;
                    update.Status = bird.BirdStatus;
                    this._context.Bird.Update(update);
                    await this._context.SaveChangesAsync();
                    return update;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Bird> DeleteBird(string BirdId)
        {
            try
            {
                var delete = await this._context.Bird.Where(x => x.BirdId.Equals(BirdId))
                                .FirstOrDefaultAsync();
                if (delete != null)
                {
                    delete.Status = false;
                    this._context.Bird.Update(delete);
                    await this._context.SaveChangesAsync();
                    return delete;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task<Bird> getBirdByID(string id)
        {
            try
            {
                var bird = await this._context.Bird.Where(x => x.BirdId.Equals(id)).FirstOrDefaultAsync();
                return bird;
            }catch  
            (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
