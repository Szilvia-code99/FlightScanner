using System.Collections.Generic;
using System.Linq;
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

    [HttpDelete("delete/{flightId}")]
    [AllowAnonymous]
    public async Task<ActionResult<string>> Delete(int flightId) {  
    Flight fl = _dataContext.Flights.Where(x => x.flightId == flightId).Single <Flight> ();  
    _dataContext.Flights.Remove(fl);  
    await _dataContext.SaveChangesAsync();  
    return "Record has successfully Deleted";  
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