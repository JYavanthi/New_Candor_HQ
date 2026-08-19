import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ApprovalTabComponent } from './approval-tab.component';

describe('ApprovalTabComponent', () => {
  let component: ApprovalTabComponent;
  let fixture: ComponentFixture<ApprovalTabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ApprovalTabComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ApprovalTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
