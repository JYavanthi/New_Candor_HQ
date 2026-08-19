import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CheckListTempAddComponent } from './check-list-temp-add.component';

describe('CheckListTempAddComponent', () => {
  let component: CheckListTempAddComponent;
  let fixture: ComponentFixture<CheckListTempAddComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CheckListTempAddComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CheckListTempAddComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
