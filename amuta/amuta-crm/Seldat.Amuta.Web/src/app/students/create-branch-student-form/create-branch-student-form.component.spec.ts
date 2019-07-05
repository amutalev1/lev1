import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateBranchStudentFormComponent } from './create-branch-student-form.component';

describe('CreateBranchStudentFormComponent', () => {
  let component: CreateBranchStudentFormComponent;
  let fixture: ComponentFixture<CreateBranchStudentFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateBranchStudentFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateBranchStudentFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
