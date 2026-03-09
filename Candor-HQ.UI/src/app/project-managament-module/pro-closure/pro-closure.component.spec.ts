import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProClosureComponent } from './pro-closure.component';

describe('ProClosureComponent', () => {
  let component: ProClosureComponent;
  let fixture: ComponentFixture<ProClosureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProClosureComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProClosureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
