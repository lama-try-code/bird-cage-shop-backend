using backend_not_clear.DTO.BirdDTO.BirdCreate;
using backend_not_clear.DTO.BirdDTO.UpdateBird;
using backend_not_clear.Models;

namespace backend_not_clear.Interface
{
    public interface IBird
    {
        //get to show all bird 
        Task<List<Bird>> GetAll();

        //get for customer
        Task<List<Bird>> GetForSort();

        //search in update bird
        //admin
        Task<List<Bird>> SearchByName(string name); 
        Task<Bird> CreateBird(CreateBird bird);
        Task<Bird> UpdateBird(UpdateBird bird);
        Task<Bird> DeleteBird(string BirdId);
        public Task<Bird> getBirdByID(string id);
    }
}
