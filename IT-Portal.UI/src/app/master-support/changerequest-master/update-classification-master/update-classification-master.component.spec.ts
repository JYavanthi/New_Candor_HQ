import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateClassificationMasterComponent } from './update-classification-master.component';

describe('UpdateClassificationMasterComponent', () => {
  let component: UpdateClassificationMasterComponent;
  let fixture: ComponentFixture<UpdateClassificationMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateClassificationMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateClassificationMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
