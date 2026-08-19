import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommonApproverComponent } from './common-approver.component';

describe('CommonApproverComponent', () => {
  let component: CommonApproverComponent;
  let fixture: ComponentFixture<CommonApproverComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CommonApproverComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CommonApproverComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
