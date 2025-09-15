import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NatureofchangeComponent } from './natureofchange.component';

describe('NatureofchangeComponent', () => {
  let component: NatureofchangeComponent;
  let fixture: ComponentFixture<NatureofchangeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NatureofchangeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NatureofchangeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
