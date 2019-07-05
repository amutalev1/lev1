import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentChildrenComponent } from './student-children.component';

describe('StudentChildrenComponent', () => {
  let component: StudentChildrenComponent;
  let fixture: ComponentFixture<StudentChildrenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentChildrenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentChildrenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
