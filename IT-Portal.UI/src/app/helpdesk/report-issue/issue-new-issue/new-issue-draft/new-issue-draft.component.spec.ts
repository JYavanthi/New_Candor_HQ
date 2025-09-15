import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewIssueDraftComponent } from './new-issue-draft.component';

describe('NewIssueDraftComponent', () => {
  let component: NewIssueDraftComponent;
  let fixture: ComponentFixture<NewIssueDraftComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewIssueDraftComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewIssueDraftComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
