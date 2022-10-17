using RailwayReservation.Business.Abstract;
using RailwayReservation.Business.Constants;
using RailwayReservation.Core.Utilities.Results;
using RailwayReservation.Entities.Concrete;
using RailwayReservation.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RailwayReservation.Business.Concrete
{
    public class ReservationManager : IReservationService
    {
        private readonly ITrainService _trainService;

        public ReservationManager(ITrainService trainService)
        {
            _trainService = trainService;
        }

        public IDataResult<ReservationDetailsDTO> RequestReservation(ReservationRequestDTO reservationRequest)
        {
            /*
             * buraya reservation request ile istenilen tren adı, kişi sayısı ve farklı vagon acceptable durumu verilecek
             * bu bilgiye göre train servisine get vb istek atacağız,
             * 
             * train servisinden bize vagondaki boş sayileri donecek
             * boş sayilar toplami istekten kucuk ise reservasyon uygun değil doneceğiz
             * eğer
             * rezervasyoon sayisi mumkun ise yerlestireceğiz
             * for vs ile
             * vagondaki sayiyi db de artiracağiz
             * 
             * vagonların boşluk durumunu kontrol edeceğiz,
             * istenilen yolcuları yerleştirene kadar son vagona kadar gideceğiz
             * hepsi yerleşirse buradan  başarılı cevabı verip hangi vagona kaç kişi yerleştirildi onun bilgisini döneceğiz
             * 
             * 

             */
            var trainInfo = _trainService.GetTrainsByName(reservationRequest.TrainName).Data;

            if (trainInfo == null)
            {
                return new ErrorDataResult<ReservationDetailsDTO>(Messages.TrainNotFound);
            }
            else
            {


                if (reservationRequest.IsDifferentVagonsAcceptable == true)//farklı vagonlara dağıtabilirsin
                {
                   var result = DistributeDifferentVagons(reservationRequest, trainInfo);
                    if (result.Success == true)
                    {
                        return new SuccessDataResult<ReservationDetailsDTO>(result.Data,result.Message);
                    }
                    else
                    {
                        return new ErrorDataResult<ReservationDetailsDTO>(result.Data, result.Message);
                    }
                    
                }
                else
                {
                    var result=TryToFitInAWagon(reservationRequest, trainInfo);//yeterli sayidda boşluğu olan tek vagon ara
                    if (result.Success == true)
                    {
                        return new SuccessDataResult<ReservationDetailsDTO>(result.Data, result.Message);
                    }
                    else
                    {
                        return new ErrorDataResult<ReservationDetailsDTO>(result.Data, result.Message);
                    }
                }

                

                

                //return new SuccessDataResult<ReservationDetailsDTO>(reservationDetails);

            }




        }
        private IDataResult<ReservationDetailsDTO> DistributeDifferentVagons(ReservationRequestDTO reservationRequest, Train trainInfo)
        {
            List<Vagon> VagonList = trainInfo.VagonList;
            ReservationDetailsDTO reservationDetails = new ReservationDetailsDTO();

            reservationDetails.SettlementDetails=new SettlementDetailDTO();
            reservationDetails.SettlementDetails.AvailableVagons=new List<VagonDto> {  };

            double requestedSeats = reservationRequest.NumberOfPassengers;

            foreach (var vagon in VagonList)
            {

                
                double capacity = vagon.Capacity;
                double takenSeats = vagon.NumberOfTakenSeats;
                double emptySeats = vagon.EmptySeats;
                double capPercentage ;

                emptySeats = capacity - takenSeats;
                capPercentage = ((takenSeats + 1) / capacity) * 100;

                //bir koltuk daha dolduğunda 70e eşit veya altında olmalı


                    while (capPercentage <= 70 && requestedSeats > 0)
                    {



                        requestedSeats-=1;//talep edilenden kalan
                    
                        takenSeats+=1;//1 kişi yerleştirdik kalan
                        vagon.SeatsJustGiven += 1; //bu rezervasyonda bu vagondan kaç koltuk vermişiz
                        emptySeats = capacity - takenSeats;
                        capPercentage = ((takenSeats + 1) / capacity) * 100;

                    }

                VagonDto vagonDto = new VagonDto() { PersonCount = vagon.SeatsJustGiven, VagonName = vagon.VagonName };
                reservationDetails.SettlementDetails.AvailableVagons.Add(vagonDto);
                        

            };
           
            

            


            if (requestedSeats == 0)//tüm talep yerleştiyse
            {
                
                reservationDetails.SettlementDetails.AvailableVagons.RemoveAll(v => v.PersonCount == 0);
                
                reservationDetails.CanBeBooked = true;
                

                return new SuccessDataResult<ReservationDetailsDTO>(reservationDetails);
            }
            else
            {
                //rezervasyon yapamaz ise false'a çevir,  array de boş gelecek zaten
                reservationDetails.CanBeBooked = false;
                return new ErrorDataResult<ReservationDetailsDTO>(reservationDetails,Messages.ReservationIsNotPossible1);

            }

        }












        private IDataResult<ReservationDetailsDTO> TryToFitInAWagon(ReservationRequestDTO reservationRequest, Train trainInfo)
        {
            double requestedSeats = reservationRequest.NumberOfPassengers;
            ReservationDetailsDTO reservationDetails = new ReservationDetailsDTO();
            reservationDetails.SettlementDetails = new SettlementDetailDTO();
            reservationDetails.SettlementDetails.AvailableVagons = new List<VagonDto> { };

            foreach (var vagon in trainInfo.VagonList)
            {


                double capacity = vagon.Capacity;
                double takenSeats = vagon.NumberOfTakenSeats;
                double emptySeats = vagon.EmptySeats; 
                double requestedPercentage ;

                
                emptySeats = capacity - takenSeats;
                requestedPercentage = ((takenSeats + requestedSeats) / capacity) * 100;

                if (requestedPercentage <= 70 && requestedSeats > 0)
                {

                    takenSeats = requestedSeats;
                    vagon.SeatsJustGiven = (int)takenSeats;
                    requestedSeats = 0;
                }
                VagonDto vagonDto = new VagonDto() { PersonCount = vagon.SeatsJustGiven, VagonName = vagon.VagonName };
                reservationDetails.SettlementDetails.AvailableVagons.Add(vagonDto);
            }
            if (requestedSeats == 0)//tüm talep yerleştiyse
            {


                reservationDetails.SettlementDetails.AvailableVagons.RemoveAll(v => v.PersonCount == 0);

                reservationDetails.CanBeBooked = true;
                return new SuccessDataResult<ReservationDetailsDTO>(reservationDetails);
            }
            else
            {//rezervasyon yapamaz ise false'a çevir,  array de boş gelecek zaten
                reservationDetails.CanBeBooked=false;
                reservationDetails.SettlementDetails.AvailableVagons.Clear();
                return new ErrorDataResult<ReservationDetailsDTO>(reservationDetails, Messages.ReservationIsNotPossible2);


            }


        }

    }
}
