using Dapper;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace DataLayer
{
    public class UserData : IUserData
    {
        private readonly IOptions<Connections> _connections;

        public UserData(IOptions<Connections> connections)
        {
            _connections = connections;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            try
            {
                string query = "select * from [dbo].[User]";
                IDbConnection connection = new SqlConnection(_connections.Value.ConnectionString);
                return (await connection.QueryAsync<UserModel>(query, commandType: CommandType.Text, commandTimeout: _connections.Value.ConnectionTimeout)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<int> CreateUser(CreateUserRequest createUserRequest)
        {
            try
            {
                using IDbConnection connection = new SqlConnection(_connections.Value.ConnectionString);
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("UserName", createUserRequest.UserName);
                parameter.Add("PasswordHash", createUserRequest.PasswordHash);
                parameter.Add("Email", createUserRequest.Email);
                parameter.Add("FirstName", createUserRequest.FirstName);
                parameter.Add("LastName", createUserRequest.LastName);
                parameter.Add("PhoneNumber", createUserRequest.PhoneNumber);
                return await connection.ExecuteAsync(StoredProcedures.CreateUser, parameter, commandType: CommandType.StoredProcedure, commandTimeout: _connections.Value.ConnectionTimeout);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> ValidateUser(UserModel userModel)
        {

            try
            {
                using IDbConnection connection = new SqlConnection(_connections.Value.ConnectionString);
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("UserName", userModel.UserName);
                parameter.Add("PasswordHash", userModel.PasswordHash);
             
                var value= await connection.ExecuteScalarAsync(StoredProcedures.ValidateUSer, parameter, commandType: CommandType.StoredProcedure, commandTimeout: _connections.Value.ConnectionTimeout);
                if(value != null && Convert.ToInt32(value) == 1)
                    return true;
                else return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
