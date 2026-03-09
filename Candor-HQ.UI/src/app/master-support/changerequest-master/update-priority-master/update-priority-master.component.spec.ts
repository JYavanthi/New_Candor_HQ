import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatePriorityMasterComponent } from './update-priority-master.component';

describe('UpdatePriorityMasterComponent', () => {
  let component: UpdatePriorityMasterComponent;
  let fixture: ComponentFixture<UpdatePriorityMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdatePriorityMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdatePriorityMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
