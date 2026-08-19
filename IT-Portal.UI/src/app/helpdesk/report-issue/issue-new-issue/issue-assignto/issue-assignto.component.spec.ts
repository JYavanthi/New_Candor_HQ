import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IssueAssigntoComponent } from './issue-assignto.component';

describe('IssueAssigntoComponent', () => {
  let component: IssueAssigntoComponent;
  let fixture: ComponentFixture<IssueAssigntoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [IssueAssigntoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(IssueAssigntoComponent);
    fixture = TestBed.createComponent(IssueAssigntoComponent);
    fixture = TestBed.createComponent(IssueAssigntoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
