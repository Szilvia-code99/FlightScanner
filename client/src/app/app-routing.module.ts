import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FlightComponent } from './flight/flight.component';
import { HomeComponent } from './home/home.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: '', component: RegisterComponent},
  { path: 'app-register', component: RegisterComponent,
  children: [
    {
      path: 'child-a', // child route path
      component: FlightComponent, // child route component that the router renders
    },
   
  ], },
  
  { path: 'app-flight', component: FlightComponent },
  { path: 'app-home', component: HomeComponent },

  //{ path: '**', component: NotFoundComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
