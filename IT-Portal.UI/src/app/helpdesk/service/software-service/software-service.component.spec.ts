import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SoftwareServiceComponent } from './software-service.component';

describe('SoftwareServiceComponent', () => {
  let component: SoftwareServiceComponent;
  let fixture: ComponentFixture<SoftwareServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SoftwareServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SoftwareServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
