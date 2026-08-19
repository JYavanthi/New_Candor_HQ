import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProjectlessonComponent } from './projectlesson.component';

describe('ProjectlessonComponent', () => {
  let component: ProjectlessonComponent;
  let fixture: ComponentFixture<ProjectlessonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProjectlessonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProjectlessonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
