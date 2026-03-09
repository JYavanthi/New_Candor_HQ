import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrAttachmentComponent } from './pr-attachment.component';

describe('PrAttachmentComponent', () => {
  let component: PrAttachmentComponent;
  let fixture: ComponentFixture<PrAttachmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PrAttachmentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PrAttachmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
