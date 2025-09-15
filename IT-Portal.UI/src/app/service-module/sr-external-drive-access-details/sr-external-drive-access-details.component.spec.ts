import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrExternalDriveAccessDetailsComponent } from './sr-external-drive-access-details.component';

describe('SrExternalDriveAccessDetailsComponent', () => {
  let component: SrExternalDriveAccessDetailsComponent;
  let fixture: ComponentFixture<SrExternalDriveAccessDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrExternalDriveAccessDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrExternalDriveAccessDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
