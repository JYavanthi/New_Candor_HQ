import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrDomainComponent } from './sr-domain.component';

describe('SrDomainComponent', () => {
  let component: SrDomainComponent;
  let fixture: ComponentFixture<SrDomainComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrDomainComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrDomainComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
