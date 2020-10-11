using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Data.DTO;
using API.Entities;

namespace API.Interfaces
{
    public interface IFlightsRepository
    {
         
         Task<IEnumerable<Flight>> GetFlights();
         Task<Flight> GetFlight(int flightId);
         Task<Flight> CreateFlight(Flight flight);
         Task<Flight> UpdateFlight(Flight flight);
         void DeleteFlight(int flightId);
         bool SaveChanges();

    }
}