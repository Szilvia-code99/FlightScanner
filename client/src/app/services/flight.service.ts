import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { NgModel } from '@angular/forms';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { Flight } from '../models/flight';

@Injectable({
  providedIn: 'root'
})

export class FlightService {
  baseUrl = 'http://localhost:5001/api/';

  readonly httpOptions = {
    headers: new HttpHeaders({
      'Content-Type':  'application/json',
    })
  };

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

  searchFlights(model: any): Observable<Flight[]> {
    console.log(model.departureTime);
    return this.http
     .get<Flight[]>(
     ' http://localhost:5001/api/flight',
       this.httpOptions
     )
     .pipe(
       map((flights) => flights.filter((flight) => (flight.origin === model.origin
                                                   && flight.destination === model.destination
                                                   && flight.departureTime >= model.departureTime
                                                   && flight.arrivalTime <= model.arrivalTime) ))
                                                   //2020-09-07T:00:00:00 datetime format
     );
    
 }
}
