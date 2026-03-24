using HotelBookingWebsite.Models;
using HotelBookingWebsite.Services;
using HotelBookingWebsite.Services.Interfaces;
using HotelBookingWebsite.DTOs.Hotel;
using Microsoft.AspNetCore.Mvc;

namespace HotelBookingWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IHotelService _service;

        public HotelController(IHotelService service)
        {
            _service = service;
        }

        // ✅ GET ALL HOTELS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var hotels = await _service.GetAllHotels();
            return Ok(hotels);
        }

        // ✅ GET HOTEL BY ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var hotel = await _service.GetHotelById(id);
            if (hotel == null)
                return NotFound("Hotel not found");

            return Ok(hotel);
        }

        // ✅ CREATE HOTEL (NO AUTH NOW)
        [HttpPost]
        public async Task<IActionResult> Create(Hotel hotel)
        {
            var result = await _service.CreateHotel(hotel);
            return Ok(result);
        }

        // ✅ UPDATE HOTEL
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Hotel hotel)
        {
            var result = await _service.UpdateHotel(id, hotel);
            if (!result)
                return NotFound("Hotel not found");

            return Ok("Hotel updated successfully");
        }

        // ✅ DELETE HOTEL
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _service.DeleteHotel(id);
            if (!result)
                return NotFound("Hotel not found");

            return Ok("Hotel deleted successfully");
        }
    }
}