import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrVpnAccessDetailsComponent } from './sr-vpn-access-details.component';

describe('SrVpnAccessDetailsComponent', () => {
  let component: SrVpnAccessDetailsComponent;
  let fixture: ComponentFixture<SrVpnAccessDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrVpnAccessDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrVpnAccessDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
