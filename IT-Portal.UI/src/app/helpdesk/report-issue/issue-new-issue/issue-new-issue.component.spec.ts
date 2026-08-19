import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IssueNewIssueComponent } from './issue-new-issue.component';

describe('IssueNewIssueComponent', () => {
  let component: IssueNewIssueComponent;
  let fixture: ComponentFixture<IssueNewIssueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [IssueNewIssueComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(IssueNewIssueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
