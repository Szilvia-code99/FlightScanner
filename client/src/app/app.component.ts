import { Component,OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Flight reservation';
  users: any;

  ngOnInit(): void{
  this.getUsers();
  }

  constructor(private httpClient: HttpClient){}

  getUsers(){
   return this.httpClient.get(
    'http://localhost:5001/api/users').
    subscribe(
      response => {this.users = response; },
       error => {console.log(error);
      });
  }
}

