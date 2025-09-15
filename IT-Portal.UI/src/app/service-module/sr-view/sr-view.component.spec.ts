import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrViewComponent } from './sr-view.component';

describe('SrViewComponent', () => {
  let component: SrViewComponent;
  let fixture: ComponentFixture<SrViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrViewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
