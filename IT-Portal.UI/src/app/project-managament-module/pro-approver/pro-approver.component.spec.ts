import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProApproverComponent } from './pro-approver.component';

describe('ProApproverComponent', () => {
  let component: ProApproverComponent;
  let fixture: ComponentFixture<ProApproverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProApproverComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProApproverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
