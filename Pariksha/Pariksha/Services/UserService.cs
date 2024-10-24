using Pariksha.Entities;
using Pariksha.Repository;


namespace Pariksha.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repository;   
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<Users>> GetAll() => await _repository.GetAll();  
        public async Task<bool> AddUser(Users users) => await _repository.AddUser(users);   
        public async Task<bool> UpdateUser(Users users) => await _repository.UpdateUser(users); 
        public async Task<bool> DeleteUser(int user_id) => await _repository.DeleteUser(user_id);   


    }
}
