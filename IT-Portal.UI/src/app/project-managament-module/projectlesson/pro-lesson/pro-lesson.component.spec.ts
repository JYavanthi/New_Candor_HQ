import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProLessonComponent } from './pro-lesson.component';

describe('ProLessonComponent', () => {
  let component: ProLessonComponent;
  let fixture: ComponentFixture<ProLessonComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProLessonComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProLessonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
