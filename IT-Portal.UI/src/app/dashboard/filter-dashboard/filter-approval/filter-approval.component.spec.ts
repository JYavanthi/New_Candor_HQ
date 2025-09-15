import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterApprovalComponent } from './filter-approval.component';

describe('FilterApprovalComponent', () => {
  let component: FilterApprovalComponent;
  let fixture: ComponentFixture<FilterApprovalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FilterApprovalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FilterApprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
