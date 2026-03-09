import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrWindowsLoginDetailsComponent } from './sr-windows-login-details.component';

describe('SrWindowsLoginDetailsComponent', () => {
  let component: SrWindowsLoginDetailsComponent;
  let fixture: ComponentFixture<SrWindowsLoginDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrWindowsLoginDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrWindowsLoginDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
