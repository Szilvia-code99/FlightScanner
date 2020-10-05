import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { User } from '../user';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = 'http://localhost:5001/api/';
  private currentUserSource = new ReplaySubject<User>(1);
  currentUser = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  login(model: any){
    return this.http.post(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    );
  }

  register(model: any){
    return this.http.post(this.baseUrl + 'account/register', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
      })
    );
  }

  setCurrentUser(user: User): void{
    this.currentUserSource.next(user);
  }

  logout(): void{
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
  
  getUsers(){
    return this.http.get(
     'http://localhost:5001/api/users');
    
   }
}
