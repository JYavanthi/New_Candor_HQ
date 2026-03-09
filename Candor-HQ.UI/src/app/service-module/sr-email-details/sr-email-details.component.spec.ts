import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrEmailDetailsComponent } from './sr-email-details.component';

describe('SrEmailDetailsComponent', () => {
  let component: SrEmailDetailsComponent;
  let fixture: ComponentFixture<SrEmailDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrEmailDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrEmailDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
