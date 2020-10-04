import { Component,OnInit } from '@angular/core';
import {HttpClient} from '@angular/common/http';
import { AccountService } from './services/account.service';
import { User } from './user';

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
  this.setCurrentUser();
  }

 
  constructor(private httpClient: HttpClient , private accountService: AccountService){}

  getUsers() {
    this.accountService.getUsers().
    subscribe(
      response => {this.users = response; },
       error => {console.log(error);
      });
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user'));
    this.accountService.setCurrentUser(user);
  }
 
}

