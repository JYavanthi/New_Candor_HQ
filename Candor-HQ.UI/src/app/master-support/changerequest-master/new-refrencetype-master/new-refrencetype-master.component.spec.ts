import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewRefrencetypeMasterComponent } from './new-refrencetype-master.component';

describe('NewRefrencetypeMasterComponent', () => {
  let component: NewRefrencetypeMasterComponent;
  let fixture: ComponentFixture<NewRefrencetypeMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewRefrencetypeMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewRefrencetypeMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
