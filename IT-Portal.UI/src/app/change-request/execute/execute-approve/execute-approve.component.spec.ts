import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExecuteApproveComponent } from './execute-approve.component';

describe('ExecuteApproveComponent', () => {
  let component: ExecuteApproveComponent;
  let fixture: ComponentFixture<ExecuteApproveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExecuteApproveComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExecuteApproveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
