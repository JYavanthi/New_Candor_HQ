import { ComponentFixture, TestBed } from '@angular/core/testing';

import { IssuereportComponent } from './issuereport.component';

describe('IssuereportComponent', () => {
  let component: IssuereportComponent;
  let fixture: ComponentFixture<IssuereportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [IssuereportComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(IssuereportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
