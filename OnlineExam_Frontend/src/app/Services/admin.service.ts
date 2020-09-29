import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http:HttpClient) { }
  baseUrl: string = "https://localhost:44301/api/admins/upload/";

  addJava(data){
    return this.http.post(this.baseUrl+"uploadJava",data);
  }
  addPhp(data){
    return this.http.post(this.baseUrl+"uploadPhp",data);
  }
  addSql(data){
    return this.http.post(this.baseUrl+"uploadSql",data);
  }
  addCplus(data){
    return this.http.post(this.baseUrl+"uploadCplus",data);
  }
  addPython(data){
    return this.http.post(this.baseUrl+"uploadPython",data);
  }
  addCSharp(data){
    return this.http.post(this.baseUrl+"uploadCsharp",data);
  }

  getAllSets(data){
    return this.http.post(this.baseUrl+"Available",data);
  }



  removeJava(data){
    return this.http.post(this.baseUrl+"removeJava",data);
  }
  removePhp(data){
    return this.http.post(this.baseUrl+"removePhp",data);
  }
  removeSql(data){
    return this.http.post(this.baseUrl+"removeSql",data);
  }
  removeCplus(data){
    return this.http.post(this.baseUrl+"removeCplus",data);
  }
  removePython(data){
    return this.http.post(this.baseUrl+"removePython",data);
  }
  removeCSharp(data){
    return this.http.post(this.baseUrl+"removeCsharp",data);
  }
}
