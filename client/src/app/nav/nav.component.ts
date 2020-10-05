import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  loadLoginComponent = false;

  constructor() {}

  ngOnInit() {}

  loadLogInComponent() {
    this.loadLoginComponent = true;
   }
   
}

