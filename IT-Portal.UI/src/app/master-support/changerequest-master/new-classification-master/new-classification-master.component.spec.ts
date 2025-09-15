import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewClassificationMasterComponent } from './new-classification-master.component';

describe('NewClassificationMasterComponent', () => {
  let component: NewClassificationMasterComponent;
  let fixture: ComponentFixture<NewClassificationMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewClassificationMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewClassificationMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
