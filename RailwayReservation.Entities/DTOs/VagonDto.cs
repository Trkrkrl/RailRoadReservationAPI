using RailwayReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Entities.DTOs
{
    public class VagonDto:IDto
    {
        public string VagonName { get; set; }
        public int PersonCount { get; set; }
    }
}
