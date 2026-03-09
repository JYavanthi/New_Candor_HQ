import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VpnAccessServiceComponent } from './vpn-access-service.component';

describe('VpnAccessServiceComponent', () => {
  let component: VpnAccessServiceComponent;
  let fixture: ComponentFixture<VpnAccessServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [VpnAccessServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VpnAccessServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
