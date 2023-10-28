using Dapper;
using DataLayer.IData;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace DataLayer
{
    public class StatusData : IStatusData
    {
        private readonly IOptions<Connections> _connections;

        public StatusData(IOptions<Connections> connections)
        {
            _connections = connections;
        }

        public async Task<List<StatusModel>> GetStatus()
        {
            try
            {

                IDbConnection connection = new SqlConnection(_connections.Value.ConnectionString);
                return (await connection.QueryAsync<StatusModel>(StoredProcedures.getStatus, commandType: CommandType.StoredProcedure, commandTimeout: _connections.Value.ConnectionTimeout)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        
    }
}
