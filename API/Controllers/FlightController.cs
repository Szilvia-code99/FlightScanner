using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.DTO;
using API.Entities;
using API.Helpers;
using API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class FlightController: BaseApiController
    {
        private readonly DataContext _dataContext;

        private readonly FlightsRepository _flightRepository;

        private readonly Automapper _autoMapper;

        public FlightController(DataContext dataContext,FlightsRepository flightRepository, Automapper autoMapper)
        {
            _dataContext = dataContext;
            _flightRepository=flightRepository;
            _autoMapper=autoMapper;

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
        public async Task<ActionResult <FlightDTO>> Create(FlightDTO flightData){
         var flightModel = _autoMapper.Map<Flight>(flightData);

         await  _flightRepository.CreateFlight(flightData);

           return Ok();
        }

    [HttpDelete("delete/{flightId}")]
    [AllowAnonymous]
    public ActionResult Delete(int flightId) {  
       flightRepository.DeleteFlight(flightId);
    }  

     [HttpPut("update")]
     [AllowAnonymous]
    public async Task<ActionResult<string>> Update(int flightId, FlightDTO flightData) {  
    Flight fl = _dataContext.Flights.Where(x => x.flightId == flightId).FirstOrDefault<Flight> ();  

     if (fl != null)
            {
            fl.airlineName=flightData.airlineName; 
            fl.origin=flightData.origin;
            fl.destination=flightData.destination;
            fl.departureTime=flightData.departureTime;
            fl.arrivalTime=flightData.arrivalTime;
            fl.totalSeats=flightData.totalSeats;
            fl.price=flightData.price;

          _dataContext.Entry(fl).State = EntityState.Modified;
           await _dataContext.SaveChangesAsync();
            return "Record has successfully Deleted";  
            }
            else
            {
                return NotFound();
            }
   
    }  
    
    }
 }