import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewPriorityMasterComponent } from './new-priority-master.component';

describe('NewPriorityMasterComponent', () => {
  let component: NewPriorityMasterComponent;
  let fixture: ComponentFixture<NewPriorityMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewPriorityMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewPriorityMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
