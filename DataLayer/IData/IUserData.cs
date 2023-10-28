using Entities;

namespace DataLayer
{
    public interface IUserData
    {
        Task<List<UserModel>> GetUsers();
        Task<int> CreateUser(CreateUserRequest createUserRequest);
        Task<bool> ValidateUser(UserModel userModel);
    }
}
