import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProDocumentsComponent } from './pro-documents.component';

describe('ProDocumentsComponent', () => {
  let component: ProDocumentsComponent;
  let fixture: ComponentFixture<ProDocumentsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProDocumentsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProDocumentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
