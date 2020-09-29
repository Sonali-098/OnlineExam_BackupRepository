import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { LoginService } from 'src/app/Services/login.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  registerCheck:boolean=false;

  constructor(private _registerService:LoginService, private _formBuilder:FormBuilder, private _router:Router,private _toastr:ToastrService) { 

    this.registerForm=this._formBuilder.group({
      full_name: ['', [Validators.required,Validators.pattern('[a-zA-Z ]*')]],
      mobile: ['', [Validators.required,Validators.minLength(10),Validators.maxLength(10),Validators.pattern("^[0-9]*$")]],
      email_id: ['', [Validators.required,Validators.email]], 
      password: ['', [Validators.required,Validators.minLength(6)]],
      confirm_password:['',[Validators.required,Validators.minLength(6)]],
      city: ['', [Validators.required]],
      state: ['', [Validators.required]],
      dob: ['', [Validators.required]],
      qualification: ['', [Validators.required]], 
      yoc: ['', [Validators.required]],
      // For Captcha
      // reCaptcha: [null,[Validators.required]]
    });
  }

  ngOnInit(): void {
  }
  get registerFormAccess(){ return this.registerForm.controls};

  register(){
    this.registerCheck=true;
    if(this.registerForm.invalid){
      return;
    }
    else{
      console.log(this.registerForm.value);
      if(this.registerForm.value['password']==this.registerForm.value['confirm_password']){
        this._registerService.registerStudent(this.registerForm.value).subscribe(
          result => {
            console.log(result);
            let tempRes=result;
            if(tempRes=="Added Successfully"){
              this._toastr.success('Success', 'User Registered Successfully');
              this._router.navigate(['']);
            }
            else if(tempRes=="Mobile Number Already Exists"){
              this._toastr.warning('Registered User','Contact Number Already Exists')
            }
            else if(tempRes=="Email ID Already Exists"){
              this._toastr.warning('Registered User','Email ID Already Exists')
            }
            else{
              this._toastr.error('Failed', 'Please Try Again');
            }
          });
      }
      else{
        this._toastr.error('Failed', 'Passwords did not match. Please Try Again');
      }      
    }
  }
}
