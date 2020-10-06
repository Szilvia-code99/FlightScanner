using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data;
using API.Data.DTO;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class FlightController: BaseApiController
    {
        private readonly DataContext _dataContext;

        public FlightController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFligths()
        {
          return await _dataContext.Flights.ToListAsync();
        }

        [HttpGet("{id}")]
        [Authorize]

        public async Task<ActionResult<Flight>> GetFlight(int id){
          return await _dataContext.Flights.FindAsync(id);
        }


        [HttpPost("create")]
        public async Task<ActionResult<FlightDTO>> Register(FlightDTO flightData){


        var flight = new Flight{
        airlineName=flightData.airlineName, 
        origin=flightData.origin,
        destination=flightData.destination,
        departureTime=flightData.departureTime,
        arrivalTime=flightData.arrivalTime,
        totalSeats=flightData.totalSeats,
        price=flightData.price
        };

      
        _dataContext.Flights.Add(flight);
        await _dataContext.SaveChangesAsync();
         
       return flightData;
         
        }

    
    }
 }