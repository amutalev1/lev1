import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ActivityHoursGridComponent } from './activity-hours-grid.component';

describe('ActivityHoursGridComponent', () => {
  let component: ActivityHoursGridComponent;
  let fixture: ComponentFixture<ActivityHoursGridComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ActivityHoursGridComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ActivityHoursGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
