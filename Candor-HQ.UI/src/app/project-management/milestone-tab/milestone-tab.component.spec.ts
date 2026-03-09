import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MilestoneTabComponent } from './milestone-tab.component';

describe('MilestoneTabComponent', () => {
  let component: MilestoneTabComponent;
  let fixture: ComponentFixture<MilestoneTabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MilestoneTabComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MilestoneTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
