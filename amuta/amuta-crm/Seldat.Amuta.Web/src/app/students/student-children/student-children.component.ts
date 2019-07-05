import { Component, OnInit } from '@angular/core';
import { StudentChild } from '../shared/models/student-child.model';

@Component({
  selector: 'app-student-children',
  templateUrl: './student-children.component.html',
  styleUrls: ['./student-children.component.scss']
})
export class StudentChildrenComponent implements OnInit {

  studChild:StudentChild=new StudentChild();
  constructor() { }

  ngOnInit() {
  }

}
