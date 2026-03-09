import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrHistoryComponent } from './cr-history.component';

describe('CrHistoryComponent', () => {
  let component: CrHistoryComponent;
  let fixture: ComponentFixture<CrHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CrHistoryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CrHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
