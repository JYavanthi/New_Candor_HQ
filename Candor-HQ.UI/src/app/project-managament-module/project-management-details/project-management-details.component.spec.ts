import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectManagementDetailsComponent } from './project-management-details.component';

describe('ProjectManagementDetailsComponent', () => {
  let component: ProjectManagementDetailsComponent;
  let fixture: ComponentFixture<ProjectManagementDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProjectManagementDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProjectManagementDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
