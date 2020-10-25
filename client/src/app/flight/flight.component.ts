import { Component, OnInit, ViewChild } from '@angular/core';
import { Flight } from '../models/flight';
import { FlightService } from '../services/flight.service';
import {Store} from '@ngrx/store';
import * as FlightListActions from './store/flight.actions';
import { Observable, Subscription } from 'rxjs';
import * as fromFlightList from './store/flight-reducer';
import { FlightModel } from '../models/flight.model';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-flight',
  templateUrl: './flight.component.html',
  styleUrls: ['./flight.component.css']
})
export class FlightComponent implements OnInit {
model: any = {};
modelUpdate: FlightModel;
//flights: any;
flightListState: Observable<{ flights: FlightModel[]}>;
deleteFlightId: any;
subscription: Subscription;
@ViewChild('updateFlightForm') flForm: NgForm;
editMode = false;
editedItem: FlightModel;

  constructor(private flightService: FlightService, private store: Store<fromFlightList.AppState>) { }

  ngOnInit(): void {
  this.flightListState = this.store.select('flightList');

    this.subscription = this.store.select('flightList')
    .subscribe(
      data => {
        if (data.editedFlightIndex > -1) {
          this.editedItem = data.editedFlight;
          this.editMode = true;
          this.flForm.setValue({
            airlineName: this.editedItem.airlineName,
          //  amount: this.editedItem.amount
          })
        } else {
          this.editMode = false;
        }
      }
    );
    console.log("hi");
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
    //  this.flights = response;
    }, error => {
      console.log(error);
       
    });
    console.log(this.flightListState);
  }

  deleteFlight() {
    this.flightService.deleteFlight(this.deleteFlightId);
  }

  updateFlight(form: NgForm) {
    const value = form.value;
    const newFlight = new FlightModel(value.airlineName,value.origin,value.destination,value.departureTime,value.arrivalTime,value.totalSeats,value.price)
    this.store.dispatch(
    new FlightListActions.UpdateFlight({
       flight: newFlight
     })
    );

  /*  this.flightService.updateFlight(this.modelUpdate).subscribe(response =>{
      console.log(response);
    }, error => {
      console.log(error);
    });
    console.log(this.model);
    //this.store.dispatch(new FlightActions.AddFlight())*/
  }

  searchFlight() {

    console.log(this.model);
    this.flightService.searchFlights(this.model).subscribe(response => {
    //  this.flights = response;
      console.log(this.flightListState);
    }, error => {
      console.log(error);
    });
  }


}
