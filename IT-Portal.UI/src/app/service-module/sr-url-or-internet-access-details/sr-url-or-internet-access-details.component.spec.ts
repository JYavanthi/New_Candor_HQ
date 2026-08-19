import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrUrlOrInternetAccessDetailsComponent } from './sr-url-or-internet-access-details.component';

describe('SrUrlOrInternetAccessDetailsComponent', () => {
  let component: SrUrlOrInternetAccessDetailsComponent;
  let fixture: ComponentFixture<SrUrlOrInternetAccessDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrUrlOrInternetAccessDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrUrlOrInternetAccessDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
