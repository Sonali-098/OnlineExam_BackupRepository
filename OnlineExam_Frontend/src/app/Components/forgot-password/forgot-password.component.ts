import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {
  emailVerificationForm: FormGroup;
  userEmail:string='';
  passwordUpdateForm:FormGroup;
  otp:string='';
  passwordUpdateCheck:boolean=false;
  emailCheck:boolean=false;
  otpCheck:string='';
  otpConfirm:boolean=false;
  emailSubmit:boolean=false;
  passwordSubmit:boolean=false;
  constructor(private _fpService:LoginService,private _formBuilder:FormBuilder,private _toastr:ToastrService,private _router : Router) { 
    this.emailVerificationForm=this._formBuilder.group({
      email_id: ['', [Validators.required,Validators.email]],
    });
    this.passwordUpdateForm=this._formBuilder.group({
      password: ['', [Validators.required,Validators.minLength(6)]],
    });
  }

  ngOnInit(): void {
    
  }
  get emailFormAccess(){return this.emailVerificationForm.controls};
  get passwordFormAccess(){return this.passwordUpdateForm.controls};
  sendOtp(){
    this.emailSubmit=true;
    if(this.emailVerificationForm.invalid){
      return;
    }
    else{
      this._fpService.sendEmailVerification(this.emailVerificationForm.value).subscribe(
        result => {
          this.userEmail=this.emailVerificationForm.value;
          this.otp=result.toString();
          if(this.otp.length==4){
            console.log("OTP Sent Sucessfully "+this.otp);
            this._toastr.info('Status', 'OTP Sent Sucessfully');
            this.emailCheck=true;
          }
          else{
            console.log(result)
            this._toastr.error('Failed', 'OTP Sending Failed');
          }
        });
    } 
  }
  checkOtp(){
    if(this.otpCheck.length==4 && this.otp==this.otpCheck){
      this.otpConfirm=true;
      this._toastr.success('Success', 'OTP Confirmed');
    }
    else{
      console.log("Invalid OTP Entered");
      this._toastr.error('Failed', 'OTP Incorrect Try Again');
      this.emailCheck=false;
    }
  }
  updatePassword(){
    this.passwordSubmit=true;
    if(this.passwordUpdateForm.invalid){
      return;
    }
    else{
      let data={
        "email_id":this.userEmail['email_id'],
        "password":this.passwordUpdateForm.value['password']
      }
      console.log(data);
      this._fpService.confirmPasswordUpdation(data).subscribe(
        result=>{
          let res=result;
          if(res=="Password Changed Successfully"){
            this._toastr.success('Success', 'Password Reset Sucessfull');
            this._router.navigate(['']);
          }
        });  
    }   
  }
}
