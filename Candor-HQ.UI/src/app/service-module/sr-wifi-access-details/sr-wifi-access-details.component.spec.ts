import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrWifiAccessDetailsComponent } from './sr-wifi-access-details.component';

describe('SrWifiAccessDetailsComponent', () => {
  let component: SrWifiAccessDetailsComponent;
  let fixture: ComponentFixture<SrWifiAccessDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrWifiAccessDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrWifiAccessDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
