import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule } from "@angular/common/http/testing";

import { FlightService } from './flight.service';
import { HttpClient } from '@angular/common/http';

describe('FlightService', () => {
  let service: FlightService;
  let httpClient: HttpClient;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers:[FlightService] ,
      imports:[HttpClientTestingModule]
    });
    service = TestBed.inject(FlightService);
    //httpClient = TestBed.inject(HttpClient);

  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
