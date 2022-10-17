using RailwayReservation.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Entities.Concrete
{
    public class Train:IEntity
    {
        [Key]
        public int TrainId { get; set; }
        public string  TrainName { get; set; }
        public List<Vagon> VagonList { get; set; }

    }
}
