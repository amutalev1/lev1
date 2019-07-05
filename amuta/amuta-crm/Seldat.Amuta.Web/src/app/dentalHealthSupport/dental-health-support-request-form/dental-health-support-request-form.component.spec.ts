import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DentalHealthSupportRequestFormComponent } from './dental-health-support-request-form.component';

describe('DentalHealthSupportRequestFormComponent', () => {
  let component: DentalHealthSupportRequestFormComponent;
  let fixture: ComponentFixture<DentalHealthSupportRequestFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DentalHealthSupportRequestFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DentalHealthSupportRequestFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
