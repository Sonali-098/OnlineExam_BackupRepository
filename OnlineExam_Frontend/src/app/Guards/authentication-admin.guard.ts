import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthguardAdminService } from '../Services/authguard-admin.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationAdminGuard implements CanActivate {
  constructor(private _authguardService: AuthguardAdminService, private _router: Router) {}  
  canActivate(): boolean {  
      if (!this._authguardService.gettoken()) {  
          this._router.navigateByUrl("404-invalid");  
      }  
      return this._authguardService.gettoken();  
  }
  
}
