using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RailwayReservation.Business.Abstract;
using RailwayReservation.Entities.DTOs;

namespace RailRoadReservationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _reservationService;

        public ReservationsController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }


        [HttpPost("requestreservation")]
        public IActionResult RequestReservation(ReservationRequestDTO reservationRequest) //rezervasyon isteğini alır
        {

            var result = _reservationService.RequestReservation(reservationRequest);//isteği service'e iletir ve dönen sonucu result'a tanımlar

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }









    }
}
