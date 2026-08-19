import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SlamasterComponent } from './slamaster.component';

describe('SlamasterComponent', () => {
  let component: SlamasterComponent;
  let fixture: ComponentFixture<SlamasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SlamasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SlamasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
