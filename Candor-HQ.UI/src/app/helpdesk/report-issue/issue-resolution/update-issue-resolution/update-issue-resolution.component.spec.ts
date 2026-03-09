import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateIssueResolutionComponent } from './update-issue-resolution.component';

describe('UpdateIssueResolutionComponent', () => {
  let component: UpdateIssueResolutionComponent;
  let fixture: ComponentFixture<UpdateIssueResolutionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateIssueResolutionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateIssueResolutionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
