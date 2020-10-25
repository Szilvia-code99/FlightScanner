import { Flight } from './flight';

export class FlightModel implements Flight{
    airlineName: string;
    origin: string;
    destination: string;
    departureTime: Date;
    arrivalTime: Date;
    totalSeats: number;
    price: number;
    constructor(airlineName: string,
        origin: string,
        destination: string,
        departureTime: Date,
        arrivalTime: Date,
        totalSeats: number,
        price: number,)
        
        {this.airlineName=airlineName;
        this.arrivalTime=arrivalTime;
        this.departureTime=departureTime;
        this.origin=origin;
        this.destination=destination;
        this.totalSeats=totalSeats;
        this.price=price;}
}