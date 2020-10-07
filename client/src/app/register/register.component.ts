import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AccountService } from '../services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  model: any = {};
  next = false;
  @Output() cancelRegister = new EventEmitter();
  registerForm: FormGroup;

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {
    this.initializeForm();
  }

  register(): void {
   /* this.accountService.register(this.model).subscribe(response =>{
      console.log(response);
    }, error => {
      console.log(error);
    });*/
    console.log(this.registerForm.value);
  }

  cancel(): void {
    this.cancelRegister.emit(false);
  }

  nextForm(): void {
    this.next = true;
  }
  back(): void {
    this.next = false;
  }

  initializeForm(): void {
    this.registerForm = new FormGroup({
      username: new FormControl(),
      password: new FormControl(),
      confirmPassword: new FormControl()
    })
  }
}
