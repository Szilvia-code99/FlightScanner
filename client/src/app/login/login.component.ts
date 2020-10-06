import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};
  loggedIn = false;
  loadRegister = false;
  
  constructor(private accountService : AccountService, private router: Router) { }

  ngOnInit(): void {
    this.getCurrentUser();
  }

  login(): void {
    this.accountService.login(this.model).subscribe(response =>{
      console.log(response);
      this.loggedIn = true;
      this.router.navigateByUrl('');
    }, error => {
      console.log(error);
    });
    console.log(this.model);
  }

    logout(): void {
      this.accountService.logout();
      this.loggedIn = false;
    }

    getCurrentUser() {
      this.accountService.currentUser.subscribe(user => {
        this.loggedIn = !!user;
      }, error => {
        console.log(error);
      })
    }

     loadRegisterComponent() {
       this.loadRegister = true;
     }
}
