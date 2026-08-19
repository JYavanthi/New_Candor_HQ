import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterReleasedComponent } from './filter-released.component';

describe('FilterReleasedComponent', () => {
  let component: FilterReleasedComponent;
  let fixture: ComponentFixture<FilterReleasedComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FilterReleasedComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FilterReleasedComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
