import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
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
    this.accountService.register(this.model).subscribe(response => {
      console.log(response);
    }, error => {
      console.log(error);
    });
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
      username: new FormControl('', Validators.required),
      password: new FormControl('', [Validators.required, Validators.minLength(4), Validators.maxLength(10)]),
      confirmPassword: new FormControl('', [Validators.required, this.matchPasswords('password')]),
    })
  }

  matchPasswords(matchTo: string): ValidatorFn {
    return (control: AbstractControl) => {
      return control?.value === control?.parent?.controls[matchTo].value ? null : {isMatching: true};
    };
  }
}
