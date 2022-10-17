using RailwayReservation.Core.Utilities.Results;
using RailwayReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Business.Abstract
{
    public interface ITrainService
    {
        public IDataResult<Train> GetTrainsByName(string trainName);
    }
}
