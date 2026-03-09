import { ComponentFixture, TestBed } from '@angular/core/testing';

import { WindowsLoginServiceComponent } from './windows-login-service.component';

describe('WindowsLoginServiceComponent', () => {
  let component: WindowsLoginServiceComponent;
  let fixture: ComponentFixture<WindowsLoginServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [WindowsLoginServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(WindowsLoginServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
