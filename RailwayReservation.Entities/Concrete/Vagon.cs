using RailwayReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Entities.Concrete
{
    public class Vagon:IEntity
    {
        [Key]
        public int VagonId { get; set; }
        [ForeignKey("Train")]
        public int TrainId { get; set; }
        public string VagonName { get; set; }
        public int Capacity { get; set; }
        public int NumberOfTakenSeats { get; set; }
        public int EmptySeats { get; set; }
        
        public int SeatsJustGiven { get; set; }


    }
}
