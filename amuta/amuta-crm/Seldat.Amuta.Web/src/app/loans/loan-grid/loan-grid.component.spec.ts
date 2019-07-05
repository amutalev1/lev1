import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoanGridComponent } from './loan-grid.component';

describe('LoanGridComponent', () => {
  let component: LoanGridComponent;
  let fixture: ComponentFixture<LoanGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoanGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoanGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
