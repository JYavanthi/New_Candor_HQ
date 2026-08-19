import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProMemberDetailsComponent } from './pro-member-details.component';

describe('ProMemberDetailsComponent', () => {
  let component: ProMemberDetailsComponent;
  let fixture: ComponentFixture<ProMemberDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProMemberDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProMemberDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
