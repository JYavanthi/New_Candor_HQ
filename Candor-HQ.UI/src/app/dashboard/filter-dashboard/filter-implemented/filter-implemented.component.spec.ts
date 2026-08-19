import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterImplementedComponent } from './filter-implemented.component';

describe('FilterImplementedComponent', () => {
  let component: FilterImplementedComponent;
  let fixture: ComponentFixture<FilterImplementedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FilterImplementedComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FilterImplementedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
