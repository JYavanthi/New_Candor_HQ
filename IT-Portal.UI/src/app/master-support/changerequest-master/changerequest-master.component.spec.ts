import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ChangerequestMasterComponent } from './changerequest-master.component';

describe('ChangerequestMasterComponent', () => {
  let component: ChangerequestMasterComponent;
  let fixture: ComponentFixture<ChangerequestMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ChangerequestMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ChangerequestMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
