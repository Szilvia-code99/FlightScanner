import { Component, OnInit } from '@angular/core';
import { FlightService } from '../services/flight.service';

@Component({
  selector: 'app-flight',
  templateUrl: './flight.component.html',
  styleUrls: ['./flight.component.css']
})
export class FlightComponent implements OnInit {
model:any={};
flights: any;
deleteFlightId:any;
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
    })
  }

  deleteFlight() {
    this.flightService.deleteFlight(this.deleteFlightId);
  }

  updateFlight() {
  }


}
