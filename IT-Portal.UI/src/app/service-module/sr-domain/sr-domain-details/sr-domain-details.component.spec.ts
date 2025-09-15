import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrDomainDetailsComponent } from './sr-domain-details.component';

describe('SrDomainDetailsComponent', () => {
  let component: SrDomainDetailsComponent;
  let fixture: ComponentFixture<SrDomainDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrDomainDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrDomainDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
