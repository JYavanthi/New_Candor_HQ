import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrFtpAccessDetailsComponent } from './sr-ftp-access-details.component';

describe('SrFtpAccessDetailsComponent', () => {
  let component: SrFtpAccessDetailsComponent;
  let fixture: ComponentFixture<SrFtpAccessDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrFtpAccessDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrFtpAccessDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
