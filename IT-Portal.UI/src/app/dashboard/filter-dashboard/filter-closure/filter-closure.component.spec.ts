import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterClosureComponent } from './filter-closure.component';

describe('FilterClosureComponent', () => {
  let component: FilterClosureComponent;
  let fixture: ComponentFixture<FilterClosureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FilterClosureComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FilterClosureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
