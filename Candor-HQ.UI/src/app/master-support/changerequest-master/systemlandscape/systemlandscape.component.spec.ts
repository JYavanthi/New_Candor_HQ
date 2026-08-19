import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SystemlandscapeComponent } from './systemlandscape.component';

describe('SystemlandscapeComponent', () => {
  let component: SystemlandscapeComponent;
  let fixture: ComponentFixture<SystemlandscapeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SystemlandscapeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SystemlandscapeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
