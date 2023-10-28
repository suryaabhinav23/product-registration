using DataLayer;
using Entities;

namespace BusinessLayer
{
    public class UserBusiness : IUserBusiness
    {
        private readonly IUserData _userData;

        public UserBusiness(IUserData userData)
        {
            _userData = userData;
        }
        public async Task<List<UserModel>> GetUsers()
        {
            return await _userData.GetUsers();
        }
        public async Task<int> CreateUser(CreateUserRequest createUserRequest)
        {
            return await _userData.CreateUser(createUserRequest);
        }
        public async Task<bool> ValidateUser(UserModel userModel)
        {
            return await _userData.ValidateUser(userModel);   
        }
    }
}

