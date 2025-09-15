import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrApproveTabComponent } from './cr-approve-tab.component';

describe('CrApproveTabComponent', () => {
  let component: CrApproveTabComponent;
  let fixture: ComponentFixture<CrApproveTabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CrApproveTabComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CrApproveTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
