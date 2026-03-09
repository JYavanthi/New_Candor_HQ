import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IssuetabComponent } from './issuetab.component';

describe('IssuetabComponent', () => {
  let component: IssuetabComponent;
  let fixture: ComponentFixture<IssuetabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [IssuetabComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(IssuetabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
