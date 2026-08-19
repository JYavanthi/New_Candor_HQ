import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrApproveComponent } from './cr-approve.component';

describe('CrApproveComponent', () => {
  let component: CrApproveComponent;
  let fixture: ComponentFixture<CrApproveComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CrApproveComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CrApproveComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
