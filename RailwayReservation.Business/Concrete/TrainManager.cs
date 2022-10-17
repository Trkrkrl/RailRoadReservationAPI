using RailwayReservation.Business.Abstract;
using RailwayReservation.Core.Utilities.Results;
using RailwayReservation.DataAccess.Abstract;
using RailwayReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Business.Concrete
{
    public class TrainManager:ITrainService
    {
        

        private readonly ITrainDal _trainDal;
        private readonly IVagonDal _vagonDal;

        public TrainManager(ITrainDal trainDal,IVagonDal vagonDal)
        {
            _trainDal = trainDal;

            _vagonDal = vagonDal;
        }

        public IDataResult<Train> GetTrainsByName(string trainName)
        {
            var trainToCheck = _trainDal.GetAll(t => t.TrainName == trainName).FirstOrDefault();
            if (trainToCheck != null)
            {
                
                trainToCheck.VagonList=_vagonDal.GetByTrainId(v => v.TrainId == trainToCheck.TrainId);
            }
            
            
            return new SuccessDataResult<Train>(trainToCheck);
        }
    }
}
