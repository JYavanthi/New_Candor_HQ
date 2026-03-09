import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommonAssetHistoryComponent } from './common-asset-history.component';

describe('CommonAssetHistoryComponent', () => {
  let component: CommonAssetHistoryComponent;
  let fixture: ComponentFixture<CommonAssetHistoryComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CommonAssetHistoryComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CommonAssetHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
