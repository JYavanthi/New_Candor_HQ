import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrMasterComponent } from './sr-master.component';

describe('SrMasterComponent', () => {
  let component: SrMasterComponent;
  let fixture: ComponentFixture<SrMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
