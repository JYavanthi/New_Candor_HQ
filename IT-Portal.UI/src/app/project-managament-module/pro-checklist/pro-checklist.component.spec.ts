import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProChecklistComponent } from './pro-checklist.component';

describe('ProChecklistComponent', () => {
  let component: ProChecklistComponent;
  let fixture: ComponentFixture<ProChecklistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProChecklistComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProChecklistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
