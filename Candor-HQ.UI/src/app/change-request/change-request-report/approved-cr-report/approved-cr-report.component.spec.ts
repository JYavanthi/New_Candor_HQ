import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApprovedCrReportComponent } from './approved-cr-report.component';

describe('ApprovedCrReportComponent', () => {
  let component: ApprovedCrReportComponent;
  let fixture: ComponentFixture<ApprovedCrReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ApprovedCrReportComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ApprovedCrReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
