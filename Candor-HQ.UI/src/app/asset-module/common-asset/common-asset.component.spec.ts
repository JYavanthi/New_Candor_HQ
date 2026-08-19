import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CommonAssetComponent } from './common-asset.component';

describe('CommonAssetComponent', () => {
  let component: CommonAssetComponent;
  let fixture: ComponentFixture<CommonAssetComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CommonAssetComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CommonAssetComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
