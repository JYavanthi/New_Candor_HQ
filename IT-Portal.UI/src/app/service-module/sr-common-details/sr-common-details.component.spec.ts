import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrCommonDetailsComponent } from './sr-common-details.component';

describe('SrCommonDetailsComponent', () => {
  let component: SrCommonDetailsComponent;
  let fixture: ComponentFixture<SrCommonDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrCommonDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrCommonDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
