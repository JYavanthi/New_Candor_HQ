import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SoftSerResolutionComponent } from './soft-ser-resolution.component';

describe('SoftSerResolutionComponent', () => {
  let component: SoftSerResolutionComponent;
  let fixture: ComponentFixture<SoftSerResolutionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SoftSerResolutionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SoftSerResolutionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
