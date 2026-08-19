import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrAddtaskComponent } from './cr-addtask.component';

describe('CrAddtaskComponent', () => {
  let component: CrAddtaskComponent;
  let fixture: ComponentFixture<CrAddtaskComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CrAddtaskComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CrAddtaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
