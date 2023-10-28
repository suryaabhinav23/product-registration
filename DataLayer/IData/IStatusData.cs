using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.IData
{
    public interface IStatusData

    {
        public Task<List<StatusModel>> GetStatus();

    }
}
