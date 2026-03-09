import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateRefrencetypeMasterComponent } from './update-refrencetype-master.component';

describe('UpdateRefrencetypeMasterComponent', () => {
  let component: UpdateRefrencetypeMasterComponent;
  let fixture: ComponentFixture<UpdateRefrencetypeMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateRefrencetypeMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateRefrencetypeMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
