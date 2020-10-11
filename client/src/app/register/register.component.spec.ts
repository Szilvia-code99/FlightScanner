import { HttpClientTestingModule } from '@angular/common/http/testing';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AccountService } from '../services/account.service';

import { RegisterComponent } from './register.component';

describe('RegisterComponent', () => {
  let component: RegisterComponent;
  let fixture: ComponentFixture<RegisterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RegisterComponent ],
      providers: [AccountService],
      imports: [HttpClientTestingModule]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RegisterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('form should be valid', () => {
    component.userPasswordRegisterForm.controls['username'].setValue('plupluplu');
    component.userPasswordRegisterForm.controls['password'].setValue('pamppampam');
    component.userPasswordRegisterForm.controls['confirmPassword'].setValue('pamppampam');
    expect(component.userPasswordRegisterForm.valid).toBeTruthy();
  });

  it('form should be invalid', () => {
    component.userPasswordRegisterForm.controls['username'].setValue('plupluplu');
    component.userPasswordRegisterForm.controls['password'].setValue('dududud');
    component.userPasswordRegisterForm.controls['confirmPassword'].setValue('pamppampam');
    expect(component.userPasswordRegisterForm.valid).toBeFalsy();
  });


});
