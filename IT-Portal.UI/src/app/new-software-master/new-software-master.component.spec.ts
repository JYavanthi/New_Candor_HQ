import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewSoftwareMasterComponent } from './new-software-master.component';

describe('NewSoftwareMasterComponent', () => {
  let component: NewSoftwareMasterComponent;
  let fixture: ComponentFixture<NewSoftwareMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewSoftwareMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewSoftwareMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
