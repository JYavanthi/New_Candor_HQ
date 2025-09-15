import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UsbAccessServiceComponent } from './usb-access-service.component';

describe('UsbAccessServiceComponent', () => {
  let component: UsbAccessServiceComponent;
  let fixture: ComponentFixture<UsbAccessServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UsbAccessServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UsbAccessServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
