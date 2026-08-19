import { ComponentFixture, TestBed } from '@angular/core/testing';

import { InternetAccessServiceComponent } from './internet-access-service.component';

describe('InternetAccessServiceComponent', () => {
  let component: InternetAccessServiceComponent;
  let fixture: ComponentFixture<InternetAccessServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [InternetAccessServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(InternetAccessServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
