import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthguardService } from '../Services/authguard.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationGuard implements CanActivate {
  constructor(private Authguardservice: AuthguardService, private router: Router) {}  
  canActivate(): boolean {  
      if (!this.Authguardservice.gettoken()) {  
          this.router.navigateByUrl("404-invalid");  
      }  
      return this.Authguardservice.gettoken();  
  }  
}
