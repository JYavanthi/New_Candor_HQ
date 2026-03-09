import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrTaskComponent } from './cr-task.component';

describe('CrTaskComponent', () => {
  let component: CrTaskComponent;
  let fixture: ComponentFixture<CrTaskComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CrTaskComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CrTaskComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
