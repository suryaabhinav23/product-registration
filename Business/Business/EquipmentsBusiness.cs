using BusinessLayer;
using DataLayer;
using DataLayer.IData;
using Entities;

namespace BusinessLayer
{
    public class EquipmentsBusiness : IEquipmentsBusiness
    {
        private readonly IEquipmentsData _equipmentsData;
       
        public EquipmentsBusiness(IEquipmentsData equipmentsData)
        {
            _equipmentsData = equipmentsData;
        }
        public async Task<List<EquipmentsModel>> GetEquipments()
        {
            return await _equipmentsData.GetEquipments();
        }
        
       
            
    }
} 