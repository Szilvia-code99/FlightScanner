import * as FlightListActions from './flight.actions'; 
import {FlightModel} from '../../models/flight.model';

export interface AppState{
     flightList: State;
}

export interface State{
    flights: FlightModel[];
    editedFlight: FlightModel;
    editedFlightIndex: number;
}

const initialState: State = {
    flights: [new FlightModel('bubiair','budapest','dubai',new Date(),new Date(), 45,747)],
    editedFlight: null,
    editedFlightIndex: -1
};

export function flightReducer(
    state: State = initialState,
    action: FlightListActions.FlightListActions
) {
    switch(action.type){
        case FlightListActions.ADD_FLIGHT:
          return {
              ...state,
              flights: [...state.flights,action.payload]
          };

          case FlightListActions.UPDATE_FLIGHT:
            const flight = state.flights[state.editedFlightIndex];
            const updatedFlight = {
              ...flight,
              ...action.payload.flight
            };
            const flights = [...state.flights];
            flights[state.editedFlightIndex] = updatedFlight;
            return {
              ...state,
              flights: flights,
              editedFlight: null,
            };

          case FlightListActions.DELETE_FLIGHT:
            const oldFlights = [...state.flights];
            oldFlights.splice(state.editedFlightIndex, 1);
            return {
              ...state,
              flights: oldFlights,
              editedFlight: null,
            };
          default: return state;
          }
  }
 