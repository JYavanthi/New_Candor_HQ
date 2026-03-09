import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrAntivirusDetailsComponent } from './sr-antivirus-details.component';

describe('SrAntivirusDetailsComponent', () => {
  let component: SrAntivirusDetailsComponent;
  let fixture: ComponentFixture<SrAntivirusDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrAntivirusDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrAntivirusDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
