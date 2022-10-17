using RailwayReservation.Core.DataAccess.Concrete.EntityFramework;
using RailwayReservation.DataAccess.Abstract;
using RailwayReservation.DataAccess.Concrete.Context;
using RailwayReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.DataAccess.Concrete.Concrete
{
    public class EfReservationDal:EfEntityBaseRepository<Reservation, EfCoreDbContext>, IReservationDal
    {
    }
}
