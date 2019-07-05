import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateBranchFormComponent } from './create-branch-form.component';

describe('CreateBranchFormComponent', () => {
  let component: CreateBranchFormComponent;
  let fixture: ComponentFixture<CreateBranchFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateBranchFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateBranchFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
