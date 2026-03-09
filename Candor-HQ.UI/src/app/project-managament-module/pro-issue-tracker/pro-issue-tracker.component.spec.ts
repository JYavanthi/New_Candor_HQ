import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProIssueTrackerComponent } from './pro-issue-tracker.component';

describe('ProIssueTrackerComponent', () => {
  let component: ProIssueTrackerComponent;
  let fixture: ComponentFixture<ProIssueTrackerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProIssueTrackerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProIssueTrackerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
