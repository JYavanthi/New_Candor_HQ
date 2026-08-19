import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MasterSupportComponent } from './master-support.component';

describe('MasterSupportComponent', () => {
  let component: MasterSupportComponent;
  let fixture: ComponentFixture<MasterSupportComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MasterSupportComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MasterSupportComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
