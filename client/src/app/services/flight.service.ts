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
}
