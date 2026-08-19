import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectGroupMasterComponent } from './project-group-master.component';

describe('ProjectGroupMasterComponent', () => {
  let component: ProjectGroupMasterComponent;
  let fixture: ComponentFixture<ProjectGroupMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProjectGroupMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProjectGroupMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
