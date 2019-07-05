import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { HealthSupportRequestFormComponent } from './health-support-request-form.component';

describe('HealthSupportRequestFormComponent', () => {
  let component: HealthSupportRequestFormComponent;
  let fixture: ComponentFixture<HealthSupportRequestFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ HealthSupportRequestFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(HealthSupportRequestFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
