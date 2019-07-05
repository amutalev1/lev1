import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FinancialSupportRequestsGridComponent } from './financial-support-requests-grid.component';

describe('FinancialSupportRequestsGridComponent', () => {
  let component: FinancialSupportRequestsGridComponent;
  let fixture: ComponentFixture<FinancialSupportRequestsGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FinancialSupportRequestsGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FinancialSupportRequestsGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
