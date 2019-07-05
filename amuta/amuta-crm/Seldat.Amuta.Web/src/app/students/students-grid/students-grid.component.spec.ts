import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentsGridComponent } from './students-grid.component';

describe('StudentsGridComponent', () => {
  let component: StudentsGridComponent;
  let fixture: ComponentFixture<StudentsGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StudentsGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StudentsGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
