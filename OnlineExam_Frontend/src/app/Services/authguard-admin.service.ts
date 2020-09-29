import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthguardAdminService {

  constructor() { }
  gettoken(){  
    return !!sessionStorage.getItem("adminData");  
  }
}
