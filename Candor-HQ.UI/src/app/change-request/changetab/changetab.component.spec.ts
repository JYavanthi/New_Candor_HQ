import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangetabComponent } from './changetab.component';

describe('ChangetabComponent', () => {
  let component: ChangetabComponent;
  let fixture: ComponentFixture<ChangetabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ChangetabComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ChangetabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
