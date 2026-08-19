import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MileStoneReportComponent } from './mile-stone-report.component';

describe('MileStoneReportComponent', () => {
  let component: MileStoneReportComponent;
  let fixture: ComponentFixture<MileStoneReportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MileStoneReportComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MileStoneReportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
