import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProMembersComponent } from './pro-members.component';

describe('ProMembersComponent', () => {
  let component: ProMembersComponent;
  let fixture: ComponentFixture<ProMembersComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProMembersComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProMembersComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
