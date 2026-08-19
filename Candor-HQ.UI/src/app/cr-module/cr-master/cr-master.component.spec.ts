import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrMasterComponent } from './cr-master.component';

describe('CrMasterComponent', () => {
  let component: CrMasterComponent;
  let fixture: ComponentFixture<CrMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CrMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CrMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
