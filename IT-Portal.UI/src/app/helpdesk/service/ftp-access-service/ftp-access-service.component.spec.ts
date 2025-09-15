import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FtpAccessServiceComponent } from './ftp-access-service.component';

describe('FtpAccessServiceComponent', () => {
  let component: FtpAccessServiceComponent;
  let fixture: ComponentFixture<FtpAccessServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FtpAccessServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FtpAccessServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
