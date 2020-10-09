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
  model2: any = { origin : 'abudabi', destination: 'paris', departureTime: '2020-09-09', arrivalTime: '2020-09-10'};
  // loadLoginComponent = false;

  constructor(private http: HttpClient, private flightService: FlightService) { }

  ngOnInit(): void {
  }

  registerToggle(): void {
    this.registerMode = !this.registerMode;
  }

  cancelRegisterMode(event: boolean): void{
    this.registerMode = event;
  }

  //loadLogInComponent() {
  // this.loadLoginComponent = true;
  //}

  getUsers(){
    this.http.get('http://localhost:5001/api/users').subscribe(users => this.users = users);
  }

  searchFlight() {
    this.flightService.searchFlights(this.model).subscribe( error => {
      console.log(error);
    });
  }
}
