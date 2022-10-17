using RailwayReservation.Core.DataAccess.Abstract;
using RailwayReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.DataAccess.Abstract
{
    public interface ITrainDal : IBaseRepository<Train>
    {
    }
}
