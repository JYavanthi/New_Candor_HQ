import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItConsumableComponent } from './it-consumable.component';

describe('ItConsumableComponent', () => {
  let component: ItConsumableComponent;
  let fixture: ComponentFixture<ItConsumableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ItConsumableComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ItConsumableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
