
using System;
using API.Data.DTO;
using API.Entities;
using AutoMapper;

namespace API.Helpers

{
    public class Automapper: Profile
    {
        public Automapper(){
          CreateMap<RegisterDTO,User>();
          CreateMap<FlightDTO,Flight>();
        }

    }
}