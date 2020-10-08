import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Flight } from '../models/flight';

@Injectable({
  providedIn: 'root'
})

export class FlightService {
  baseUrl = 'http://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getFlights(){
    return this.http.get(
      'http://localhost:5001/api/flight');
  }

 createFlight(model: any){
    return this.http.post(this.baseUrl + 'flight/create', model).pipe(
      map((response: Flight) => {
        const flight = response;
        console.log(flight);
        }
      )
    );
  }

  updateFlight(model: any){
    return this.http.put(this.baseUrl + 'flight/update', model).pipe(
      map((response: Flight) => {
        const flight = response;
        console.log(flight);
        }
      )
    );
  }

  deleteFlight(flightId: number) {
  return this.http.delete<Flight>(this.baseUrl + `flight/delete/${flightId}`).subscribe(
    val => {
        console.error('DELETE call successful value returned in body', val);
    },
    response => {
        console.error('DELETE call in error', response);
    },
    () => {
        console.error('The DELETE observable is now completed.');
    }
  );
  }

  
}
