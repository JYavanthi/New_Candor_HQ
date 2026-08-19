import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewRefrenceMasterComponent } from './new-refrence-master.component';

describe('NewRefrenceMasterComponent', () => {
  let component: NewRefrenceMasterComponent;
  let fixture: ComponentFixture<NewRefrenceMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewRefrenceMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewRefrenceMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
