using Dapper;
using DataLayer.IData;
using Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Options;
using System.Data;

namespace DataLayer
{
    public class EquipmentsData : IEquipmentsData
    {
        private readonly IOptions<Connections> _connections;

        public EquipmentsData(IOptions<Connections> connections)
        {
            _connections = connections;
        }

        public async Task<List<EquipmentsModel>> GetEquipments()
        {
            try
            {

                IDbConnection connection = new SqlConnection(_connections.Value.ConnectionString);
                return (await connection.QueryAsync<EquipmentsModel>(StoredProcedures.getEquipments, commandType: CommandType.StoredProcedure, commandTimeout: _connections.Value.ConnectionTimeout)).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
       
            
        