import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthResponse } from '../_models/authResponse';
import { BehaviorSubject, map } from 'rxjs';
import { SignUpDTO } from '../_models/signUpDTO';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'https://localhost:7114/api/';
  private currentUserSourse = new BehaviorSubject<AuthResponse | null>(null);
  currentUser$ = this.currentUserSourse.asObservable();

  constructor(private http: HttpClient) { }

  login(model: any){
    return this.http.post<AuthResponse>(this.baseUrl + 'v1/auth/login', model).pipe(
      map((response: AuthResponse) => {
        const authResponse = response;
        if (authResponse) {
          localStorage.setItem('authResponse', JSON.stringify(authResponse));
          this.currentUserSourse.next(authResponse);
        }
      })
    )
  }

  setCurrentUser(authResponse: AuthResponse ){
    this.currentUserSourse.next(authResponse);
  }


  logout(){
    localStorage.removeItem('authResponse');
    this.currentUserSourse.next(null);
  }

  register(model: any){
    return this.http.post<SignUpDTO>(this.baseUrl + 'v1/auth/signup', model).pipe(
      map(signupDto => {
        if (signupDto){
          localStorage.setItem('signupDto', JSON.stringify(signupDto))
        }
      })
      
    )
  }
}
