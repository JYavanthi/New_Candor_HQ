import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewSoftwareVersionMasterComponent } from './new-software-version-master.component';

describe('NewSoftwareVersionMasterComponent', () => {
  let component: NewSoftwareVersionMasterComponent;
  let fixture: ComponentFixture<NewSoftwareVersionMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewSoftwareVersionMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewSoftwareVersionMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
