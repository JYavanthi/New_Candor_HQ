import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SlasummaryComponent } from './slasummary.component';

describe('SlasummaryComponent', () => {
  let component: SlasummaryComponent;
  let fixture: ComponentFixture<SlasummaryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SlasummaryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SlasummaryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
