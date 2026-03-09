import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrBreadCrumbComponent } from './cr-bread-crumb.component';

describe('CrBreadCrumbComponent', () => {
  let component: CrBreadCrumbComponent;
  let fixture: ComponentFixture<CrBreadCrumbComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CrBreadCrumbComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CrBreadCrumbComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
