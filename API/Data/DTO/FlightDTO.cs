using System;
using System.ComponentModel.DataAnnotations;

namespace API.Data.DTO
{
    public class FlightDTO
    {
         // [Required]
        public int flightId { get; set; }
       //   [Required]
        public string airlineName { get; set; }
          [Required]
        public string origin { get; set; }
        [Required]
        public string destination { get; set; }
        // [Required]
        public DateTime departureTime {get; set;}
         //[Required]
        public DateTime arrivalTime {get; set;}
        //  [Required]
        public int totalSeats {get;set;}
         // [Required]
        public float price {get;set;}
    }
}