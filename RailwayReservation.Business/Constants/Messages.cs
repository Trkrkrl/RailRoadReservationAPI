using RailwayReservation.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Business.Constants
{
    public class Messages
    {
        public static string TrainNotFound = "Bu ada sahip tren bulunamadı !";

        public static string ReservationIsNotPossible2 = "Maalesef bu trende yeterli sayıda boş yer yok";
        public static string ReservationIsNotPossible1 = "Maalesef Tek Vagonda Yeterli Boş Yer Yok , Çoklu Vagon Seçimini Deneyiniz";

    }
}
