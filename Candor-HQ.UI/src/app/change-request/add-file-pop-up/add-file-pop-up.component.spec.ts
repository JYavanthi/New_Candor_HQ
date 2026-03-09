import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddFilePopUpComponent } from './add-file-pop-up.component';

describe('AddFilePopUpComponent', () => {
  let component: AddFilePopUpComponent;
  let fixture: ComponentFixture<AddFilePopUpComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddFilePopUpComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AddFilePopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
