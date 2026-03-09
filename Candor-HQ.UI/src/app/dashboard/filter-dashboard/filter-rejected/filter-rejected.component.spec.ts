import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterRejectedComponent } from './filter-rejected.component';

describe('FilterRejectedComponent', () => {
  let component: FilterRejectedComponent;
  let fixture: ComponentFixture<FilterRejectedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FilterRejectedComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FilterRejectedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
