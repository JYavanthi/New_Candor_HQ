import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SidebrservicemoduleComponent } from './sidebrservicemodule.component';

describe('SidebrservicemoduleComponent', () => {
  let component: SidebrservicemoduleComponent;
  let fixture: ComponentFixture<SidebrservicemoduleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SidebrservicemoduleComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SidebrservicemoduleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
