import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateCrtaskComponent } from './update-crtask.component';

describe('UpdateCrtaskComponent', () => {
  let component: UpdateCrtaskComponent;
  let fixture: ComponentFixture<UpdateCrtaskComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateCrtaskComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateCrtaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
