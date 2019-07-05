import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { SharedService } from 'src/app/shared/services/shared.service';
// import {MaterialModule} from 'src/app/material/material.module'
import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { BranchService } from 'src/app/branches/shared/services/branch.service';
import { HttpErrorResponse } from '@angular/common/http';

@Component({
  selector: 'app-navigation-header',
  templateUrl: './navigation-header.component.html',
  styleUrls: ['./navigation-header.component.scss']
})
export class NavigationHeaderComponent implements OnInit {

  environment = environment;
  constructor(private sharedService: SharedService,
    private router: Router,
    private branchService: BranchService
  ) { }

  ngOnInit() {

  }

  showAllColumns() {
    this.sharedService.showAllColumnsSubject.next();
  }

  delete() {
    switch (environment.currentPage) {
      case 'students':

        break;
      case 'branches':
        this.branchService.delete().subscribe(() => {

        },
          (error: HttpErrorResponse) => {

          });;
        break;
      default:
        return;
    }

    setTimeout(() => {
      window.location.reload();
    }, 0);

  }

  search() {
    switch (environment.currentPage) {
      case 'students':

        break;
      case 'branches':
        // this.branchService.Contain().subscribe(() => {   
        //
        // },
        //   (error: HttpErrorResponse) => {
        // 
        //   }); ;
        break;
    }
  }

  add() {
    switch (environment.currentPage) {
      case 'students':
        this.router.navigate(['students/create']);
        break;
      case 'branches':
        this.router.navigate(['branches/create']);
        break;
      default:
        break;
    }
  }
}
