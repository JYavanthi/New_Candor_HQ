import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImplemetComponent } from './implemet.component';

describe('ImplemetComponent', () => {
  let component: ImplemetComponent;
  let fixture: ComponentFixture<ImplemetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ImplemetComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ImplemetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
