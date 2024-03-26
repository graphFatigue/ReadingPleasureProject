import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { Router } from '@angular/router';
import { AuthResponse } from '../_models/authResponse';
import { Observable, of } from 'rxjs';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit{

  model: any = {}
  currentUser$: Observable<AuthResponse | null> = of(null);

  constructor(private authService: AuthService, private router: Router, 
    private toastr: ToastrService){}

  ngOnInit(): void {
    this.currentUser$ = this.authService.currentUser$;
  }

  login(): void{
    this.authService.login(this.model).subscribe({
      next: _ =>  this.router.navigateByUrl('/authors'),
      error: error => this.toastr.error(error.error)
    })
  }

  logout(): void{
    this.authService.logout();
    this.router.navigateByUrl('/');
  }

}

