import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProTasksComponent } from './pro-tasks.component';

describe('ProTasksComponent', () => {
  let component: ProTasksComponent;
  let fixture: ComponentFixture<ProTasksComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProTasksComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProTasksComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
