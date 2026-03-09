import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SeekclerificatonsComponent } from './seekclerificatons.component';

describe('SeekclerificatonsComponent', () => {
  let component: SeekclerificatonsComponent;
  let fixture: ComponentFixture<SeekclerificatonsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SeekclerificatonsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SeekclerificatonsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
