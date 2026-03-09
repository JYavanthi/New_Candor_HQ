import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrExecuteComponent } from './cr-execute.component';

describe('CrExecuteComponent', () => {
  let component: CrExecuteComponent;
  let fixture: ComponentFixture<CrExecuteComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CrExecuteComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CrExecuteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
