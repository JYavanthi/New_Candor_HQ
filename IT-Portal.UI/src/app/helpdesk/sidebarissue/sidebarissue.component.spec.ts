import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidebarissueComponent } from './sidebarissue.component';

describe('SidebarissueComponent', () => {
  let component: SidebarissueComponent;
  let fixture: ComponentFixture<SidebarissueComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SidebarissueComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SidebarissueComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
