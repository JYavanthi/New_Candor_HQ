import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrCommonApprovalComponent } from './sr-common-approval.component';

describe('SrCommonApprovalComponent', () => {
  let component: SrCommonApprovalComponent;
  let fixture: ComponentFixture<SrCommonApprovalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrCommonApprovalComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrCommonApprovalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
