import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RaciReportComponent } from './raci-report.component';

describe('RaciReportComponent', () => {
  let component: RaciReportComponent;
  let fixture: ComponentFixture<RaciReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RaciReportComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RaciReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
