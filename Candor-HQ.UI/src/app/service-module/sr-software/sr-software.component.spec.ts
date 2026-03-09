import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrSoftwareComponent } from './sr-software.component';

describe('SrSoftwareComponent', () => {
  let component: SrSoftwareComponent;
  let fixture: ComponentFixture<SrSoftwareComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrSoftwareComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrSoftwareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
