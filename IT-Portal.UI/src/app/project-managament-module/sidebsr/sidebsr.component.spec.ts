import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidebsrComponent } from './sidebsr.component';

describe('SidebsrComponent', () => {
  let component: SidebsrComponent;
  let fixture: ComponentFixture<SidebsrComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SidebsrComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SidebsrComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
