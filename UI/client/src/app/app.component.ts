import { Component, OnInit } from '@angular/core';
import { AuthService } from './_services/auth.service';
import { AuthResponse } from './_models/authResponse';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Reading Pleasure';

  constructor(private authService: AuthService){}
  
  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser(){
    const userString = localStorage.getItem('authResponse');
    if (!userString) return;
    const authResponse: AuthResponse = JSON.parse(userString);
    this.authService.setCurrentUser(authResponse);
  }
}
