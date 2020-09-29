import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdminReportService {

  constructor(private _http:HttpClient) { }
  baseUrl: string = "https://localhost:44301/api/report/";

  allUserDetails(data){
    return this._http.post(this.baseUrl+"getAllReport",data);
  }
  userReport(data){
    return this._http.post(this.baseUrl+"getReport",data);
  }
  userFilteredReport(data){
    return this._http.post(this.baseUrl+"searchReport",data);
  }
  allCity(data){
    return this._http.post(this.baseUrl+"getCity",data);
  }
  allState(data){
    return this._http.post(this.baseUrl+"getState",data);
  }
}
