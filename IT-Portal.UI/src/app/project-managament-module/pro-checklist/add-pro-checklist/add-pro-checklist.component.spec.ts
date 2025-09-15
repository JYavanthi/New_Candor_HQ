import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddProChecklistComponent } from './add-pro-checklist.component';

describe('AddProChecklistComponent', () => {
  let component: AddProChecklistComponent;
  let fixture: ComponentFixture<AddProChecklistComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddProChecklistComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddProChecklistComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
