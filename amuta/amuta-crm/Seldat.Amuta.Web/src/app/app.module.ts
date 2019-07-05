import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './header/header.component';
import { FooterComponent } from './footer/footer.component';
import { TranslateModule, TranslateLoader } from "@ngx-translate/core";
import { TranslateHttpLoader } from "@ngx-translate/http-loader";
import { HttpClientModule } from '@angular/common/http';
import { HttpClient } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './material/material.module';
import { MainHeaderComponent } from './header/main-header/main-header.component';
import { NavigationHeaderComponent } from './header/navigation-header/navigation-header.component';
import { HomeComponent } from './home/home.component';
import { StudentModule } from './students/student.module';
import 'rxjs/Rx';
import { BranchModule } from './branches/branch.module';
import { PaymentModule } from './payments/payment.module';
import { ExamModule } from './exams/exam.module';
import { DentalHealthSupportModule } from './dentalHealthSupport/dental-health-support.module';
import { HealthSupportModule } from './healthSupport/health-support.module';
import { FinancialSupportModule } from './financialSupportRequest/financial-support.module';
import { LoansModule } from './loans/loans.module';
import { ScholarshipModule } from './scholarship/scholarship.module';
import { RequestsComponent } from './requests/requests.component';

export function HttpLoaderFactory(http: HttpClient) {
  return new TranslateHttpLoader(http);
}
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    MainHeaderComponent,
    NavigationHeaderComponent,
    HomeComponent,
    RequestsComponent,     
  ],
  imports: [
    StudentModule,
    BranchModule,
    PaymentModule,
    ExamModule,
    FinancialSupportModule,
    DentalHealthSupportModule,
    HealthSupportModule,
    LoansModule,
    ScholarshipModule,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    MaterialModule,
    BrowserAnimationsModule,
    TranslateModule.forRoot({
        loader: {
            provide: TranslateLoader,
            useFactory: HttpLoaderFactory,
            deps: [HttpClient]
        }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
