import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrCommonApprovetabComponent } from './sr-common-approvetab.component';

describe('SrCommonApprovetabComponent', () => {
  let component: SrCommonApprovetabComponent;
  let fixture: ComponentFixture<SrCommonApprovetabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrCommonApprovetabComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrCommonApprovetabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
