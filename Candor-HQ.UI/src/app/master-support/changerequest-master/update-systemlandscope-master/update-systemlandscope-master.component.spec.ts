import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateSystemlandscopeMasterComponent } from './update-systemlandscope-master.component';

describe('UpdateSystemlandscopeMasterComponent', () => {
  let component: UpdateSystemlandscopeMasterComponent;
  let fixture: ComponentFixture<UpdateSystemlandscopeMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateSystemlandscopeMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UpdateSystemlandscopeMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
