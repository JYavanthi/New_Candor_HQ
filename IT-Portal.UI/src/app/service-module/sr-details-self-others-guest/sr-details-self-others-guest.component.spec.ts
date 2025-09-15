import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrDetailsSelfOthersGuestComponent } from './sr-details-self-others-guest.component';

describe('SrDetailsSelfOthersGuestComponent', () => {
  let component: SrDetailsSelfOthersGuestComponent;
  let fixture: ComponentFixture<SrDetailsSelfOthersGuestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrDetailsSelfOthersGuestComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrDetailsSelfOthersGuestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
