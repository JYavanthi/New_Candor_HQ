import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrReportComponent } from './pr-report.component';

describe('PrReportComponent', () => {
  let component: PrReportComponent;
  let fixture: ComponentFixture<PrReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PrReportComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PrReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
