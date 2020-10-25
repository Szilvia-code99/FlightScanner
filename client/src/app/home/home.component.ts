import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FlightService } from '../services/flight.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  model: any = {};
  registerMode = false;
  users: any;
  flights: any;
  birthday= "salalala";
  // loadLoginComponent = false;

  constructor(private http: HttpClient, private flightService: FlightService) { }

  ngOnInit(): void {
   this.flightService.getFlights().subscribe(res=>this.flights=res);
  }

  registerToggle(): void {
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event: boolean): void{
    this.registerMode = event;
  }


  getUsers(){
    this.http.get('http://localhost:5001/api/users').subscribe(users => this.users = users);
  }

  searchFlight() {
    this.flightService.searchFlights(this.model).subscribe(response =>{
      this.flights = response;
      console.log(response);
    }, error => {
      console.log(error);
    });
    console.log(this.model);
  }
}
