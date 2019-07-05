import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AgGridModule } from 'ag-grid-angular';
import { AgGridComponent } from '../ag-grid/ag-grid.component';
import { SharedService } from './services/shared.service';
import { MaterialModule } from '../material/material.module';
import {  FormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
  declarations: [
    AgGridComponent
   
  ],
  providers:[
    SharedService
  ],
  imports: [
    CommonModule,
    AgGridModule.withComponents([]),
    MaterialModule,
    MatFormFieldModule,
    FormsModule,
    HttpClientModule
    
  ],
  exports: [
   AgGridComponent,
   MaterialModule,
   FormsModule,
   CommonModule,
 ]
})
export class SharedModule { }
