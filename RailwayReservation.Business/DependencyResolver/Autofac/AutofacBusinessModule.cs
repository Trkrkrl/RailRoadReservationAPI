using Autofac;
using RailwayReservation.Business.Abstract;
using RailwayReservation.Business.Concrete;
using RailwayReservation.DataAccess.Abstract;
using RailwayReservation.DataAccess.Concrete.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Business.DependencyResolver.Autofac
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ReservationManager>().As<IReservationService>().SingleInstance();
            builder.RegisterType<EfReservationDal>().As<IReservationDal>().SingleInstance();

            builder.RegisterType<TrainManager>().As<ITrainService>().SingleInstance();
            builder.RegisterType<EfTrainDal>().As<ITrainDal>().SingleInstance();

            builder.RegisterType<EfVagonDal>().As<IVagonDal>().SingleInstance();

        }
       
    }
}
