import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItspareComponent } from './itspare.component';

describe('ItspareComponent', () => {
  let component: ItspareComponent;
  let fixture: ComponentFixture<ItspareComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ItspareComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ItspareComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
