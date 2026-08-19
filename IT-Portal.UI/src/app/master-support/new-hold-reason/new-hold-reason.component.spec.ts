import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewHoldReasonComponent } from './new-hold-reason.component';

describe('NewHoldReasonComponent', () => {
  let component: NewHoldReasonComponent;
  let fixture: ComponentFixture<NewHoldReasonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewHoldReasonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewHoldReasonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
