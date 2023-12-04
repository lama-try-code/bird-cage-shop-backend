using backend_not_clear.DTO;
using backend_not_clear.DTO.UserDTO;
using backend_not_clear.DTO.UserDTO.SearchUserID;
using backend_not_clear.Models;

namespace backend_not_clear.Interface
{
    public interface IUser
    {
        public Task<User> CreateUser(CreateUser user);
        public Task<string> Login(LoginDTO user);
        public Task<User> Registration(RegisterDTO user);
        public Task<List<User>> SearchByName(SearchByFullNameDTO FullName);
        public Task<User> GetUserInformation(SearchUserID user);
        public Task<List<User>> GetAll();
        public Task<User> Update(UpdateDTO user);
        public Task<bool> Remove(RemoveDTO userID);
        public Task<Int32> countCustomers();
    }
}
