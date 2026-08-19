import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrApproverComponent } from './sr-approver.component';

describe('SrApproverComponent', () => {
  let component: SrApproverComponent;
  let fixture: ComponentFixture<SrApproverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrApproverComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrApproverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
