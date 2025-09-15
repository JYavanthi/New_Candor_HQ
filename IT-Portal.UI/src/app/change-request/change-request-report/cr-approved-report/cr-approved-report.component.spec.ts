import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrApprovedReportComponent } from './cr-approved-report.component';

describe('CrApprovedReportComponent', () => {
  let component: CrApprovedReportComponent;
  let fixture: ComponentFixture<CrApprovedReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CrApprovedReportComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CrApprovedReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
