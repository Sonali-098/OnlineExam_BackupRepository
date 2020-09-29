import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AdminReportService } from 'src/app/Services/admin-report.service';

@Component({
  selector: 'app-single-report-admin',
  templateUrl: './single-report-admin.component.html',
  styleUrls: ['./single-report-admin.component.css']
})
export class SingleReportAdminComponent implements OnInit {

  constructor(private _adminReportService:AdminReportService,private _router:Router,private _route:ActivatedRoute,private _toastr:ToastrService) { }
  id: string;
  details;
  detailsRendered:boolean=false;
  data=[];
  dataPieChart=[];
  dataDonutChart=[];
  userName;

  ngOnInit(): void {
    this.detailsRendered=false;
    this.getReports();
  }
  getReports(){
    this.id = this._route.snapshot.paramMap.get('id');
    this.userName=sessionStorage.getItem('userData');
    let uID={
      "user_id":this.id
    }
    let avg=0;
    this._adminReportService.userReport(uID).subscribe(result=>{
      console.log(result);
      this.details=result;
      if(this.details.length==0){
        this.detailsRendered=false;
      }
      else{
        this.detailsRendered=true;
        for(let i = 0; i<this.details.length;i++){
          this.data.push([this.details[i]["exam_name"],this.details[i]["level1_score"],this.details[i]["level2_score"],this.details[i]["level3_score"]])
          this.dataPieChart.push([this.details[i]["exam_name"],this.details[i]["level1_score"]+this.details[i]["level2_score"]+this.details[i]["level3_score"]])
          avg = avg + this.details[i]["level1_score"]+this.details[i]["level2_score"]+this.details[i]["level3_score"];
        }
        avg = avg/this.details.length;
        this.dataDonutChart.push(['Average',avg]);
        this.dataDonutChart.push(['Remaining',100 - avg]);
        console.log(this.dataDonutChart)
        console.log(this.data)
        console.log(this.dataPieChart)
      }
    });
  }
  allUser(){
    sessionStorage.removeItem('userData');
    this._router.navigate(['adminReport'])
  }
  print(){
    window.print()
  }
  logout(){
    this._router.navigate([""]);
    sessionStorage.clear();
    this._toastr.success('Success', 'Logged Out Successfully');
  }
}
