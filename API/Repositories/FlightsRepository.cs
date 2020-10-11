using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.DTO;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories
{
    public class FlightsRepository: IFlightsRepository
    {
            private readonly DataContext dataContext;
            
            public FlightsRepository(DataContext dataContext){
            
            this.dataContext=dataContext;
            }
            public async  Task<IEnumerable<Flight>> GetFlights(){

                return await dataContext.Flights.ToListAsync();
            }

         
            public async  Task<Flight> GetFlight(int flightId){
                //  return await dataContext.Flights.FindAsync(flightId);
                return await dataContext.Flights.FirstOrDefaultAsync(x => x.flightId == flightId);
            }
            public async  Task<Flight> CreateFlight(Flight flightData){

                if (flightData == null){
                    throw new ArgumentNullException(nameof(flightData));
                }
                var result= await dataContext.Flights.AddAsync(flightData);
                await dataContext.SaveChangesAsync();
                
                return result.Entity;
               
            }
            public async Task<Flight> UpdateFlight(Flight flightData){

               var result = await dataContext.Flights.FirstOrDefaultAsync(x => x.flightId == flightData.flightId && x.airlineName == flightData.airlineName);

                    if (result != null)
                        {
                        
                        result.airlineName=flightData.airlineName; 
                        result.origin=flightData.origin;
                        result.destination=flightData.destination;
                        result.departureTime=flightData.departureTime;
                        result.arrivalTime=flightData.arrivalTime;
                        result.totalSeats=flightData.totalSeats;
                        result.price=flightData.price;

                        await dataContext.SaveChangesAsync();

                        return result; 
                    }
                        return null;
            }
            public async void DeleteFlight(int flightId){
                var result= await dataContext.Flights
                    .FirstOrDefaultAsync(x => x.flightId == flightId);

                if (result!=null){
                    dataContext.Flights.Remove(result);  
                    await dataContext.SaveChangesAsync();  
                }
               
            }

        public bool SaveChanges()
        {
            return (dataContext.SaveChanges() >=0);
        }

    /*    public async Task<IEnumerable<Flight>> SearchFlights(SearchFlightDTO flight)
        {
           var flights = await dataContext.Flights.Where(x => x.origin == flight.origin
                                              //  && x.destination == flight.destination
                                                //&& x.departureTime == flight.departureTime
                                               // && x.arrivalTime == flight.arrivalTime
                                               ).ToListAsync(); 
                                               
            return flights;
        }*/



    }
}