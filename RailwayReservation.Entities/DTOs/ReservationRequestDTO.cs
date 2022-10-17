using RailwayReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Entities.DTOs
{
    public class ReservationRequestDTO:IDto
    {
        public string TrainName { get; set; }
        public int NumberOfPassengers { get; set; }
        public bool IsDifferentVagonsAcceptable { get; set; }
    }
}
