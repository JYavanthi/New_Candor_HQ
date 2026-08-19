import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DashboardNewSidebarComponent } from './dashboard-new-sidebar.component';

describe('DashboardNewSidebarComponent', () => {
  let component: DashboardNewSidebarComponent;
  let fixture: ComponentFixture<DashboardNewSidebarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DashboardNewSidebarComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DashboardNewSidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
