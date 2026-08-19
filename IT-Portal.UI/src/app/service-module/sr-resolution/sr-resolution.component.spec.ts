import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrResolutionComponent } from './sr-resolution.component';

describe('SrResolutionComponent', () => {
  let component: SrResolutionComponent;
  let fixture: ComponentFixture<SrResolutionComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrResolutionComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrResolutionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
