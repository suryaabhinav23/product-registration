using Entities;

namespace BusinessLayer
{
    public interface IUserBusiness
    {
        Task<List<UserModel>> GetUsers();
        Task<int> CreateUser(CreateUserRequest createUserRequest);
        Task<bool> ValidateUser(UserModel userModel);
    }
}
