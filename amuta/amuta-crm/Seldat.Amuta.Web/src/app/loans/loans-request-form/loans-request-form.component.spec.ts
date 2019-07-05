import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LoansRequestFormComponent } from './loans-request-form.component';

describe('LoansRequestFormComponent', () => {
  let component: LoansRequestFormComponent;
  let fixture: ComponentFixture<LoansRequestFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LoansRequestFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoansRequestFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
