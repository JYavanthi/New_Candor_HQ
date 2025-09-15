import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IssuesTrackerTabComponent } from './issues-tracker-tab.component';

describe('IssuesTrackerTabComponent', () => {
  let component: IssuesTrackerTabComponent;
  let fixture: ComponentFixture<IssuesTrackerTabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [IssuesTrackerTabComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(IssuesTrackerTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
