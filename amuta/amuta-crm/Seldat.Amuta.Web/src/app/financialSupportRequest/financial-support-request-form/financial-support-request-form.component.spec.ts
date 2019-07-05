import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FinancialSupportRequestFormComponent } from './financial-support-request-form.component';

describe('FinancialSupportRequestFormComponent', () => {
  let component: FinancialSupportRequestFormComponent;
  let fixture: ComponentFixture<FinancialSupportRequestFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FinancialSupportRequestFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FinancialSupportRequestFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
