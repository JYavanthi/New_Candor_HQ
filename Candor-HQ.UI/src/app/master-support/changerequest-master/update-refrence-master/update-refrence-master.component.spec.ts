import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateRefrenceMasterComponent } from './update-refrence-master.component';

describe('UpdateRefrenceMasterComponent', () => {
  let component: UpdateRefrenceMasterComponent;
  let fixture: ComponentFixture<UpdateRefrenceMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateRefrenceMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateRefrenceMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
