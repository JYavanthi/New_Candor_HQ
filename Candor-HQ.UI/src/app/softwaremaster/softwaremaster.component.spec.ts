import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SoftwaremasterComponent } from './softwaremaster.component';

describe('SoftwaremasterComponent', () => {
  let component: SoftwaremasterComponent;
  let fixture: ComponentFixture<SoftwaremasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SoftwaremasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SoftwaremasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
