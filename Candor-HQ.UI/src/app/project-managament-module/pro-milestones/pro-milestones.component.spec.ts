import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProMilestonesComponent } from './pro-milestones.component';

describe('ProMilestonesComponent', () => {
  let component: ProMilestonesComponent;
  let fixture: ComponentFixture<ProMilestonesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProMilestonesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProMilestonesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
