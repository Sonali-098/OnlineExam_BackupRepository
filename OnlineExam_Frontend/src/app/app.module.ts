import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';
import { MatToolbarModule } from '@angular/material/toolbar'
import { GoogleChartsModule } from 'angular-google-charts';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegisterComponent } from './Components/register/register.component';
import { LoginComponent } from './Components/login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { NotFoundComponent } from './Components/not-found/not-found.component';
import { ForgotPasswordComponent } from './Components/forgot-password/forgot-password.component';
import { AdminDashboardComponent } from './Components/admin-dashboard/admin-dashboard.component';
import { StudentDashboardComponent } from './Components/student-dashboard/student-dashboard.component';
import { RecaptchaModule, RECAPTCHA_SETTINGS, RecaptchaSettings } from 'ng-recaptcha';
import { RecaptchaFormsModule } from 'ng-recaptcha';
import { AdminTestComponent } from './Components/admin-test/admin-test.component';
import { AdminReportsComponent } from './Components/admin-reports/admin-reports.component';
import { SingleReportAdminComponent } from './Components/single-report-admin/single-report-admin.component';


@NgModule({
  declarations: [
    AppComponent,
    RegisterComponent,
    LoginComponent,
    NotFoundComponent,
    ForgotPasswordComponent,
    AdminDashboardComponent,
    StudentDashboardComponent,
    AdminTestComponent,
    AdminReportsComponent,
    SingleReportAdminComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    ToastrModule.forRoot(),
    RecaptchaModule,
    RecaptchaFormsModule,
    MatToolbarModule,
    GoogleChartsModule
  ],
  providers: [{
    provide: RECAPTCHA_SETTINGS,
    useValue: {
      siteKey: '6LeIxAcTAAAAAJcZVRqyHh71UMIEGNQ_MXjiZKhI',
    } as RecaptchaSettings,
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
