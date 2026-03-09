import { ComponentFixture, TestBed } from '@angular/core/testing';

import { OnHoldReasonComponent } from './on-hold-reason.component';

describe('OnHoldReasonComponent', () => {
  let component: OnHoldReasonComponent;
  let fixture: ComponentFixture<OnHoldReasonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [OnHoldReasonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(OnHoldReasonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
