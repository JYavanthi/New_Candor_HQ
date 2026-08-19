import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SoftwareVersionMasterComponent } from './software-version-master.component';

describe('SoftwareVersionMasterComponent', () => {
  let component: SoftwareVersionMasterComponent;
  let fixture: ComponentFixture<SoftwareVersionMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SoftwareVersionMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SoftwareVersionMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
