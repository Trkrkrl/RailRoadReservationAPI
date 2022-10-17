using RailwayReservation.Core.Entities;
using RailwayReservation.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Entities.DTOs
{
    public class SettlementDetailDTO:IDto
    {
        public List<VagonDto> AvailableVagons { get; set; }
    }
}
