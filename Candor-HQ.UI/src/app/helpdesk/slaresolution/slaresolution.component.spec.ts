import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SlaresolutionComponent } from './slaresolution.component';

describe('SlaresolutionComponent', () => {
  let component: SlaresolutionComponent;
  let fixture: ComponentFixture<SlaresolutionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SlaresolutionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SlaresolutionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
