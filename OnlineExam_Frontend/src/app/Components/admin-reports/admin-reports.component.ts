import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AdminReportService } from 'src/app/Services/admin-report.service';

@Component({
  selector: 'app-admin-reports',
  templateUrl: './admin-reports.component.html',
  styleUrls: ['./admin-reports.component.css']
})
export class AdminReportsComponent implements OnInit {
  data;
  allUserData;
  selectedUser;
  selectedUserCheck:boolean=false;
  userDataReceived:boolean=false;
  searchForm:FormGroup;
  allCityList;
  allStateList;
  subjectList=['Java','SQL','PHP','C/C++','Python','C#/.Net']
  selectedTech;
  level=['L1','L2','L3','L1,L2','L2,L3','L1,L3','L1,L2,L3']
  selectedCity;
  selectedState;
  selectedLevel;
  searchBasedList;
  marksEntered;
  L12Level:boolean=false;
  L3Level:boolean=false;
  L1L2Level:boolean=false;
  L2L3Level:boolean=false;
  L1L3Level:boolean=false;
  L123Level:boolean=false;
  max;
  filterBasedTable: boolean;

  constructor(private _adminReportService:AdminReportService,private _router:Router,private _toastr:ToastrService,private _formBuilder:FormBuilder) { 
  }
  ngOnInit(): void {
    this.getAllUser();
    this.getCity();
    this.getStates();
  }
  getAllUser(){
    this._adminReportService.allUserDetails(this.data).subscribe(result=>{
      console.log(result);
      this.allUserData=result;
    });
    this.userDataReceived=true;
  }
  filterSearch(){
    // console.log(this.selectedTech);
    // console.log(this.selectedCity);
    // console.log(this.selectedState);
    // console.log(this.selectedLevel);
    // console.log(this.marksEntered);
    let levelsData;
    if(this.selectedLevel=="L1"){
      levelsData=["1"];
    }
    else if(this.selectedLevel=="L2"){
      levelsData=["2"];
    }
    else if(this.selectedLevel=="L3"){
      levelsData=["3"];
    }
    else if(this.selectedLevel=="L1,L2"){
      levelsData=["1","2"];
    }
    else if(this.selectedLevel=="L1,L3"){
      levelsData=["1","3"];
    }
    else if(this.selectedLevel=="L2,L3"){
      levelsData=["2","3"];
    }
    else if(this.selectedLevel=="L1,L2,L3"){
      levelsData=["1","2","3"];
    }

    if((this.selectedLevel=="L1"||this.selectedLevel=="L2")&&(this.marksEntered>=0 && this.marksEntered<=40)){
      let data={
        "tech":this.selectedTech,
        "city":this.selectedCity,
        "state":this.selectedState,
        "level":levelsData,
        "marks":this.marksEntered
      }
      this._adminReportService.userFilteredReport(data).subscribe(result=>{
        console.log(result)
        this.searchBasedList=result
      });
    }
    else if((this.selectedLevel=="L3")&&(this.marksEntered>=0 && this.marksEntered<=20)){
      let data={
        "tech":this.selectedTech,
        "city":this.selectedCity,
        "state":this.selectedState,
        "level":levelsData,
        "marks":this.marksEntered
      }
      this._adminReportService.userFilteredReport(data).subscribe(result=>{
        console.log(result);
        this.searchBasedList=result
      });
    }
    else if((this.selectedLevel=="L2,L3"||this.selectedLevel=="L1,L3")&&(this.marksEntered>=0 && this.marksEntered<=60)){
      let data={
        "tech":this.selectedTech,
        "city":this.selectedCity,
        "state":this.selectedState,
        "level":levelsData,
        "marks":this.marksEntered
      }
      this._adminReportService.userFilteredReport(data).subscribe(result=>{
        console.log(result);
        this.searchBasedList=result
      });
    }
    else if((this.selectedLevel=="L1,L2")&&(this.marksEntered>=0 && this.marksEntered<=80)){
      let data={
        "tech":this.selectedTech,
        "city":this.selectedCity,
        "state":this.selectedState,
        "level":levelsData,
        "marks":this.marksEntered
      }
      this._adminReportService.userFilteredReport(data).subscribe(result=>{
        console.log(result);
        this.searchBasedList=result
      });
    }
    else if((this.selectedLevel=="L1,L2,L3")&&(this.marksEntered>=0 && this.marksEntered<=100)){
      let data={
        "tech":this.selectedTech,
        "city":this.selectedCity,
        "state":this.selectedState,
        "level":levelsData,
        "marks":this.marksEntered
      }
      this._adminReportService.userFilteredReport(data).subscribe(result=>{
        console.log(result);
        this.searchBasedList=result
      });
    }
    else{
      this._toastr.error("Failed","Invalid Input");
    }
    
  }
  levelSelected(){
    if(this.selectedLevel=="L1"||this.selectedLevel=="L2"){
      this.L12Level=true;
      this.L3Level=false;
      this.L1L2Level=false;
      this.L2L3Level=false;
      this.L1L3Level=false;
      this.L123Level=false;
    }
    else if(this.selectedLevel=="L3"){
      this.L12Level=false;
      this.L3Level=true;
      this.L1L2Level=false;
      this.L2L3Level=false;
      this.L1L3Level=false;
      this.L123Level=false;
    }
    else if(this.selectedLevel=="L1,L2"){
      this.L12Level=false;
      this.L3Level=false;
      this.L1L2Level=true;
      this.L2L3Level=false;
      this.L1L3Level=false;
      this.L123Level=false;
    }
    else if(this.selectedLevel=="L2,L3"){
      this.L12Level=false;
      this.L3Level=false;
      this.L1L2Level=false;
      this.L2L3Level=true;
      this.L1L3Level=false;
      this.L123Level=false;
    }
    else if(this.selectedLevel=="L1,L3"){
      this.L12Level=false;
      this.L3Level=false;
      this.L1L2Level=false;
      this.L2L3Level=false;
      this.L1L3Level=true;
      this.L123Level=false;
    }
    else if(this.selectedLevel=="L1,L2,L3"){
      this.L12Level=false;
      this.L3Level=false;
      this.L1L2Level=false;
      this.L2L3Level=false;
      this.L1L3Level=false;
      this.L123Level=true;
    }
  }
  getParticularReport(id,uname){
    sessionStorage.setItem('userData',uname);
    this._router.navigate(['detailReport',id]);
    // this.selectedUserCheck=true;
    // let uID={
    //   "user_id":id
    // }
    // this._adminReportService.userReport(uID).subscribe(result=>{
    //   console.log(result);
    //   this.selectedUser=result;
    // }); 
  }
  getStates(){
    this._adminReportService.allState(this.data).subscribe(result=>{
      console.log(result);
      this.allStateList=result;
    });
  }
  getCity(){
    console.log("In")
    this._adminReportService.allCity(this.data).subscribe(result=>{
      console.log(result);
      this.allCityList=result;
    });
  }
  displaySearchTable(){
    this.userDataReceived=false;
    this.filterBasedTable=true;
  }
  logout(){
    this._router.navigate([""]);
    sessionStorage.clear();
    this._toastr.success('Success', 'Logged Out Successfully');
  }
}
