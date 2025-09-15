import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrVirtualMeetingDetailsComponent } from './sr-virtual-meeting-details.component';

describe('SrVirtualMeetingDetailsComponent', () => {
  let component: SrVirtualMeetingDetailsComponent;
  let fixture: ComponentFixture<SrVirtualMeetingDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrVirtualMeetingDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrVirtualMeetingDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
