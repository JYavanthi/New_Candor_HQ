import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CitrixAccessServiceComponent } from './citrix-access-service.component';

describe('CitrixAccessServiceComponent', () => {
  let component: CitrixAccessServiceComponent;
  let fixture: ComponentFixture<CitrixAccessServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CitrixAccessServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CitrixAccessServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
