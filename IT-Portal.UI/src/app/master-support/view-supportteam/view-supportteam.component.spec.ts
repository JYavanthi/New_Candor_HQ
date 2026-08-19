import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSupportteamComponent } from './view-supportteam.component';

describe('ViewSupportteamComponent', () => {
  let component: ViewSupportteamComponent;
  let fixture: ComponentFixture<ViewSupportteamComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ViewSupportteamComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ViewSupportteamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
