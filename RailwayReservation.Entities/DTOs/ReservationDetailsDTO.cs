using RailwayReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Entities.DTOs
{
    public class ReservationDetailsDTO:IDto
    {

        public bool CanBeBooked { get; set; }
        public SettlementDetailDTO SettlementDetails { get; set; }
    }
}
