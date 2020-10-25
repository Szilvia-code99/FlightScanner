import {Action} from '@ngrx/store';
import { fromEventPattern } from 'rxjs';
import { FlightModel } from 'src/app/models/flight.model';
import { Flight } from '../../models/flight';

export const ADD_FLIGHT = 'ADD_FLIGHT';
export const UPDATE_FLIGHT = 'UPDATE_FLIGHT';
export const DELETE_FLIGHT = 'DELETE_FLIGHT';
export const START_EDIT = 'START_EDIT';
export const STOP_EDIT = 'STOP_EDIT';


export class AddFlight implements Action{
    readonly type = ADD_FLIGHT;
   
    constructor(public payload: FlightModel){}
} 

export class UpdateFlight implements Action{
    readonly type = UPDATE_FLIGHT;
   
    constructor(public payload:{flight: FlightModel}){}
} 

export class DeleteFlight implements Action{
    readonly type = DELETE_FLIGHT;
   
    constructor(public payload: number){}
} 


export class StartEdit implements Action {
    readonly type = START_EDIT;
  
    constructor(public payload: number) {}
  }
  
  export class StopEdit implements Action {
    readonly type = STOP_EDIT;
  }
  

export type FlightListActions =
| AddFlight
| UpdateFlight
| DeleteFlight;

