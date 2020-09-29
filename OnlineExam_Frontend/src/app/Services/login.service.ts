import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  constructor(private http:HttpClient) { }

  baseUrl: string = "https://localhost:44301/api/accounts/";

  validateStudent(data){
    return this.http.post(this.baseUrl+"getUser",data);
  }
  validateAdmin(data){
    return this.http.post(this.baseUrl+"getAdmin",data);
  }
  registerStudent(data){
    return this.http.post(this.baseUrl+"registerUser",data);
  }
  sendEmailVerification(data){
    return this.http.post(this.baseUrl+"sendMail",data);
  }
  confirmPasswordUpdation(data){
    return this.http.post(this.baseUrl+"resetPassword",data);
  }
}