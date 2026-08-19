import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProMilestoneDetailsComponent } from './pro-milestone-details.component';

describe('ProMilestoneDetailsComponent', () => {
  let component: ProMilestoneDetailsComponent;
  let fixture: ComponentFixture<ProMilestoneDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProMilestoneDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProMilestoneDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
