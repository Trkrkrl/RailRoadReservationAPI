using RailwayReservation.Core.Utilities.Results;
using RailwayReservation.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Business.Abstract
{
    public interface IReservationService
    {
        IDataResult<ReservationDetailsDTO> RequestReservation(ReservationRequestDTO reservationRequest);
    }
}
