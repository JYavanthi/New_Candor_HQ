import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterPendingComponent } from './filter-pending.component';

describe('FilterPendingComponent', () => {
  let component: FilterPendingComponent;
  let fixture: ComponentFixture<FilterPendingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FilterPendingComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FilterPendingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
