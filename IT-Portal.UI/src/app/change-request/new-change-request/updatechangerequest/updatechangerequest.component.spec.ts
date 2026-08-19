import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdatechangerequestComponent } from './updatechangerequest.component';

describe('UpdatechangerequestComponent', () => {
  let component: UpdatechangerequestComponent;
  let fixture: ComponentFixture<UpdatechangerequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdatechangerequestComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdatechangerequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
