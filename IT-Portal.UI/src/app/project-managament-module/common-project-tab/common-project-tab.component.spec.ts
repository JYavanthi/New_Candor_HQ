import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommonProjectTabComponent } from './common-project-tab.component';

describe('CommonProjectTabComponent', () => {
  let component: CommonProjectTabComponent;
  let fixture: ComponentFixture<CommonProjectTabComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CommonProjectTabComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CommonProjectTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
