import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MultAttachmentComponent } from './mult-attachment.component';

describe('MultAttachmentComponent', () => {
  let component: MultAttachmentComponent;
  let fixture: ComponentFixture<MultAttachmentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MultAttachmentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MultAttachmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
