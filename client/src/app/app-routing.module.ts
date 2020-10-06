import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FlightComponent } from './flight/flight.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';

const routes: Routes = [
  { path: 'app-login', component: LoginComponent },
  { path: 'app-register', component: RegisterComponent },
  { path: 'app-flightr', component: FlightComponent },
 { path: '', component: HomeComponent,pathMatch: 'full'},
 { path: '**', component: HomeComponent }, // redirect to `home-component`}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
