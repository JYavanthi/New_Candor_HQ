import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrCommonHistoryComponent } from './sr-common-history.component';

describe('SrCommonHistoryComponent', () => {
  let component: SrCommonHistoryComponent;
  let fixture: ComponentFixture<SrCommonHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrCommonHistoryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrCommonHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
