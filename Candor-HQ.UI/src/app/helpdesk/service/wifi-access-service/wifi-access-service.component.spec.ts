import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WifiAccessServiceComponent } from './wifi-access-service.component';

describe('WifiAccessServiceComponent', () => {
  let component: WifiAccessServiceComponent;
  let fixture: ComponentFixture<WifiAccessServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WifiAccessServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WifiAccessServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
