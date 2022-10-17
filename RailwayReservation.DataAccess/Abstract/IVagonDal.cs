using RailwayReservation.Core.DataAccess.Abstract;
using RailwayReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.DataAccess.Abstract
{
    public interface IVagonDal : IBaseRepository<Vagon>
    {
        List<Vagon> GetByTrainId(Expression<Func<Vagon, bool>> filter = null);
    }
}
