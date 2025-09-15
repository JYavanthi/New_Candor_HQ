import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItSpareComponent } from './it-spare.component';

describe('ItSpareComponent', () => {
  let component: ItSpareComponent;
  let fixture: ComponentFixture<ItSpareComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ItSpareComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ItSpareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
