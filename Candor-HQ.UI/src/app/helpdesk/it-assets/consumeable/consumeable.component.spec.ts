import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsumeableComponent } from './consumeable.component';

describe('ConsumeableComponent', () => {
  let component: ConsumeableComponent;
  let fixture: ComponentFixture<ConsumeableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ConsumeableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ConsumeableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
