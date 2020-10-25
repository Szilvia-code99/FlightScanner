import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NavComponent } from './nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RegisterComponent } from './register/register.component';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { FlightComponent } from './flight/flight.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ButtonColorChangingDirective } from './button-color-changing.directive';
import { NotFoundComponent } from './not-found/not-found.component';
import { StoreModule } from '@ngrx/store';
import { flightReducer } from './flight/store/flight-reducer';
import * as fromFlightList from './flight/store/flight-reducer';

@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    RegisterComponent,
    HomeComponent,
    FlightComponent,
    ButtonColorChangingDirective,
    NotFoundComponent,
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FormsModule,
    NgbModule,
    ReactiveFormsModule,
    StoreModule.forRoot({flightList: flightReducer}),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
