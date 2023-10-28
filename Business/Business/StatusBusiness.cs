using BusinessLayer;
using DataLayer;
using DataLayer.IData;
using Entities;

namespace BusinessLayer
{
    public class StatusBusiness : IStatusBusiness
    {
        private readonly IStatusData _statusData;

        public StatusBusiness(IStatusData statusData)
        {
            _statusData = statusData;
        }

        public async Task<List<StatusModel>> GetStatus()
        {
            return await _statusData.GetStatus();
        }





    }
}
