import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrCitrixAccessDetailsComponent } from './sr-citrix-access-details.component';

describe('SrCitrixAccessDetailsComponent', () => {
  let component: SrCitrixAccessDetailsComponent;
  let fixture: ComponentFixture<SrCitrixAccessDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrCitrixAccessDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrCitrixAccessDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
