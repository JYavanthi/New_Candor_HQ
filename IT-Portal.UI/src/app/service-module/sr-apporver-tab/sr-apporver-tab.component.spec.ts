import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrApporverTabComponent } from './sr-apporver-tab.component';

describe('SrApporverTabComponent', () => {
  let component: SrApporverTabComponent;
  let fixture: ComponentFixture<SrApporverTabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrApporverTabComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrApporverTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
