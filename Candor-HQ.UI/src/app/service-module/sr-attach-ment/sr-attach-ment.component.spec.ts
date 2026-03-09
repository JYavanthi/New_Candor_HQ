import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrAttachMentComponent } from './sr-attach-ment.component';

describe('SrAttachMentComponent', () => {
  let component: SrAttachMentComponent;
  let fixture: ComponentFixture<SrAttachMentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrAttachMentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrAttachMentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
