import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ScholarshipRequestFormComponent } from './scholarship-request-form.component';

describe('ScholarshipRequestFormComponent', () => {
  let component: ScholarshipRequestFormComponent;
  let fixture: ComponentFixture<ScholarshipRequestFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ScholarshipRequestFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ScholarshipRequestFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
