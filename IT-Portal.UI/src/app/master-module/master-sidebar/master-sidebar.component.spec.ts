import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MasterSidebarComponent } from './master-sidebar.component';

describe('MasterSidebarComponent', () => {
  let component: MasterSidebarComponent;
  let fixture: ComponentFixture<MasterSidebarComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MasterSidebarComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MasterSidebarComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
