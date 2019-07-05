import { Component, OnInit, Input } from '@angular/core';
import { Branch } from 'src/app/branches/shared/models/branch.model';

@Component({
  selector: 'app-branch-details',
  templateUrl: './branch-details.component.html',
  styleUrls: ['./branch-details.component.scss']
})
export class BranchDetailsComponent implements OnInit {
  @Input() branch: Branch;
  constructor() { }

  ngOnInit() {
  }

}
