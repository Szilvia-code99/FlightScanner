using System;

namespace API.Data.DTO
{
    public class FlightDTO
    {
         public int flightId { get; set; }
        public string airlineName { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }

        public DateTime departureTime {get; set;}

         public DateTime arrivalTime {get; set;}

         public int totalSeats {get;set;}

         public float price {get;set;}
    }
}