import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrUsbAccessDetailsComponent } from './sr-usb-access-details.component';

describe('SrUsbAccessDetailsComponent', () => {
  let component: SrUsbAccessDetailsComponent;
  let fixture: ComponentFixture<SrUsbAccessDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrUsbAccessDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrUsbAccessDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
