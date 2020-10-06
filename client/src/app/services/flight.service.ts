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

  deleteFlight(flightId: number) {
  return this.http.delete(this.baseUrl + 'flight/1').subscribe(
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

  /*
  updateNoteCategory(note: Note, newCategory: string): void{
    this.httpClient.put<Note>( this.baseUrl + `/Notes/${note.id}`, {
      id: note.id,
      title: note.title,
      text: note.text,
      category: newCategory,
      ownerId: note.ownerId,
      textColor: note.textColor,
      color: note.color,
      pinned: note.pinned}, this.httpOptions).subscribe(
        val => {
            console.error('PUT call successful value returned in body', val);
        },
        response => {
            console.error('PUT call in error', response);
        },
        () => {
            console.error('The PUT observable is now completed.');
        }
    );
  }
*/
}
