import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  //loadLoginComponent = false;
  model: any = {};
  loggedIn = false;

  constructor(public accountService: AccountService, private router: Router) {}

  ngOnInit() {}

  //loadLogInComponent() {
  //  this.loadLoginComponent = true;
  // }
  login() {
    this.accountService.login(this.model).subscribe(response => {
      this.router.navigateByUrl('/app-flight');
      this.loggedIn=true;
    })
  }
 
  logout() {
    this.accountService.logout();
    this.router.navigateByUrl('/');
  }


}
