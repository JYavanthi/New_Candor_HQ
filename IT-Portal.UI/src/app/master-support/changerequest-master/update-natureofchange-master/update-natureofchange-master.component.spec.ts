import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateNatureofchangeMasterComponent } from './update-natureofchange-master.component';

describe('UpdateNatureofchangeMasterComponent', () => {
  let component: UpdateNatureofchangeMasterComponent;
  let fixture: ComponentFixture<UpdateNatureofchangeMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateNatureofchangeMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateNatureofchangeMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
