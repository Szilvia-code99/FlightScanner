import { HttpClient, HttpClientModule } from '@angular/common/http';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { FormsModule } from '@angular/forms';
import { FlightService } from '../services/flight.service';

import { FlightComponent } from './flight.component';

describe('FlightComponent', () => {
  let component: FlightComponent;
  let fixture: ComponentFixture<FlightComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ FlightComponent ],
      providers: [FlightService],
      imports: [HttpClientTestingModule, FormsModule]
    }),
      fixture = TestBed.createComponent(FlightComponent);
      component = fixture.componentInstance;

  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('it should have 3 flights', () => {
    component.getFlights();
    expect(component.flights.length).toEqual(3);
  });
});
