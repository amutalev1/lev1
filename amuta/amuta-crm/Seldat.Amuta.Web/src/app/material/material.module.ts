import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import {MatInputModule} from '@angular/material/input';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {
  MatSidenavModule,
  MatToolbarModule,MatButtonModule,
  MatIconModule,
  MatListModule,MatTabsModule, MatFormFieldModule,MatCheckboxModule, MatMenuModule
} from '@angular/material';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,MatInputModule,MatGridListModule,MatSidenavModule, MatToolbarModule,MatTabsModule,
    MatIconModule,
    MatListModule,MatButtonModule,MatProgressSpinnerModule,MatFormFieldModule,MatCheckboxModule, MatMenuModule
  ],
  exports:[MatInputModule,MatGridListModule,MatSidenavModule, MatToolbarModule,MatTabsModule,
    MatIconModule,
    MatListModule,MatButtonModule,MatProgressSpinnerModule,MatFormFieldModule,MatCheckboxModule, MatMenuModule]
})
export class MaterialModule { }

