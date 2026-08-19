import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FilterDraftComponent } from './filter-draft.component';

describe('FilterDraftComponent', () => {
  let component: FilterDraftComponent;
  let fixture: ComponentFixture<FilterDraftComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [FilterDraftComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FilterDraftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
