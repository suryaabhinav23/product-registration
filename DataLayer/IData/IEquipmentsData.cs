using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IData
{
    public interface IEquipmentsData
    {

       public Task<List<EquipmentsModel>> GetEquipments();
        

        
        }
    }

