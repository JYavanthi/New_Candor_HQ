import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewSystemlandscopeMasterComponent } from './new-systemlandscope-master.component';

describe('NewSystemlandscopeMasterComponent', () => {
  let component: NewSystemlandscopeMasterComponent;
  let fixture: ComponentFixture<NewSystemlandscopeMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewSystemlandscopeMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewSystemlandscopeMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
