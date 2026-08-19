import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewChangeRequestComponent } from './new-change-request.component';

describe('NewChangeRequestComponent', () => {
  let component: NewChangeRequestComponent;
  let fixture: ComponentFixture<NewChangeRequestComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewChangeRequestComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewChangeRequestComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
