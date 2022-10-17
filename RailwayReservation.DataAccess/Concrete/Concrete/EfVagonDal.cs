using RailwayReservation.Core.DataAccess.Concrete.EntityFramework;
using RailwayReservation.DataAccess.Abstract;
using RailwayReservation.DataAccess.Concrete.Context;
using RailwayReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.DataAccess.Concrete.Concrete
{
    public class EfVagonDal : EfEntityBaseRepository<Vagon, EfCoreDbContext>, IVagonDal
    {
        public List<Vagon> GetByTrainId(Expression<Func<Vagon, bool>> filter = null)
        {
            using (EfCoreDbContext context = new EfCoreDbContext())
            {
                var result = from va in context.Vagons
                             join tra in context.Trains on va.TrainId equals tra.TrainId
                             select new Vagon
                             {
                                 TrainId = va.TrainId,
                                 VagonId = va.VagonId,
                                 VagonName = va.VagonName,
                                 EmptySeats = va.EmptySeats,
                                 Capacity = va.Capacity,
                                 NumberOfTakenSeats = va.NumberOfTakenSeats,
                                 SeatsJustGiven = va.SeatsJustGiven,
                             };
                return filter == null ? result.ToList() : result.Where(filter).ToList();

            }
        }
    }
}
