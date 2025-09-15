import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DomainServiceComponent } from './domain-service.component';

describe('DomainServiceComponent', () => {
  let component: DomainServiceComponent;
  let fixture: ComponentFixture<DomainServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [DomainServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(DomainServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
