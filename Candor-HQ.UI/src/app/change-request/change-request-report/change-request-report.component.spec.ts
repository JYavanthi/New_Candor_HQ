import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangeRequestReportComponent } from './change-request-report.component';

describe('ChangeRequestReportComponent', () => {
  let component: ChangeRequestReportComponent;
  let fixture: ComponentFixture<ChangeRequestReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ChangeRequestReportComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ChangeRequestReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
