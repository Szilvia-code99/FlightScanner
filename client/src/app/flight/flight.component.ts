import { Component, OnInit } from '@angular/core';
import { Flight } from '../models/flight';
import { FlightService } from '../services/flight.service';

@Component({
  selector: 'app-flight',
  templateUrl: './flight.component.html',
  styleUrls: ['./flight.component.css']
})
export class FlightComponent implements OnInit {
model: any = {};
modelUpdate: any = {};
flights: any;
deleteFlightId: any;
  constructor(private flightService: FlightService) { }

  ngOnInit(): void {
  }

  createFlight(): void {
    this.flightService.createFlight(this.model).subscribe(response =>{
      console.log(response);
    }, error => {
      console.log(error);
    });
    console.log(this.model);
  }

  getFlights() {
    this.flightService.getFlights().subscribe(response => {
      this.flights = response;
    }, error => {
      console.log(error);
      
    });
    console.log(this.flights);
  }

  deleteFlight() {
    this.flightService.deleteFlight(this.deleteFlightId);
  }

  updateFlight() {
    this.flightService.updateFlight(this.modelUpdate).subscribe(response =>{
      console.log(response);
    }, error => {
      console.log(error);
    });
    console.log(this.model);
  }

  searchFlight() {

    console.log(this.model);
    this.flightService.searchFlights(this.model).subscribe(response => {
      this.flights = response;
      console.log(this.flights);
    }, error => {
      console.log(error);
    });
  }


}
