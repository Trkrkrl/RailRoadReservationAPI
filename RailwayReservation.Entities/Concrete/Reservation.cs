using RailwayReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Entities.Concrete
{
    public class Reservation:IEntity
    {
        [Key]
        public int ReservationId { get; set; }
        
        
        public Train Train { get; set; }
        public int NumberOfPassengers { get; set; }
        public bool IsDifferentVagonsAcceptable { get; set; }
    }
}
