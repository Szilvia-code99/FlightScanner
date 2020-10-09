using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Data.DTO;
using API.Entities;
using API.Helpers;
using API.Interfaces;
using API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [AllowAnonymous]
    public class FlightController: BaseApiController
    {
        private readonly DataContext _dataContext;

        private readonly IFlightsRepository _flightRepository;
         private readonly IMapper _mapper;

         //GET api/flight
        public FlightController(DataContext dataContext,IFlightsRepository flightRepository,IMapper mapper)
        {
            _dataContext = dataContext;
            _flightRepository=flightRepository;
            _mapper=mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flight>>> GetFligths()
        {
            var flightItems = await _flightRepository.GetFlights();
           if(flightItems != null){
            return Ok(_mapper.Map<IEnumerable<FlightDTO>>(flightItems));
          }
          return NotFound();
        }

        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Flight>>> SearchFlights(FlightDTO flightData){
        //  string origin/*, string destination, DateTime departure, DateTime arrival*/){
           var flightModel = _mapper.Map<Flight>(flightData);
          var flights= await _flightRepository.SearchFlights(flightModel);
          if(flights != null){
            return Ok(_mapper.Map<IEnumerable<FlightDTO>>(flights));
          }
          return NotFound();
        }

        //GET api/flight/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<FlightDTO>> GetFlight(int id){
          var flightItem = await _flightRepository.GetFlight(id);

          if(flightItem != null){
            return Ok(_mapper.Map<FlightDTO>(flightItem));
          }
          return NotFound();
        }



        [HttpPost("create")]
        public async Task<ActionResult <FlightDTO>> Create(FlightDTO flightData){
         var flightModel = _mapper.Map<Flight>(flightData);
         
        await  _flightRepository.CreateFlight(flightModel);

        return Ok(flightModel);
        }

        [HttpDelete("delete/{flightId}")]
        public ActionResult Delete(int flightId) {  
          _flightRepository.DeleteFlight(flightId);
          return Ok();
        }  

        [HttpPut("update")]
        public async Task<ActionResult> Update(FlightDTO flightData) {  
        var flightModel =  await _flightRepository.GetFlight(flightData.flightId);

        if (flightModel == null){
          return NotFound();
        }
         _mapper.Map(flightData,flightModel);
         await _flightRepository.UpdateFlight(flightModel);

         return Ok();

        }  
        
    }
 }