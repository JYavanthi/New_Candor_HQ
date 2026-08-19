import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrImplementComponent } from './cr-implement.component';

describe('CrImplementComponent', () => {
  let component: CrImplementComponent;
  let fixture: ComponentFixture<CrImplementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CrImplementComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CrImplementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
