import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrRemoteAccessDetailsComponent } from './sr-remote-access-details.component';

describe('SrRemoteAccessDetailsComponent', () => {
  let component: SrRemoteAccessDetailsComponent;
  let fixture: ComponentFixture<SrRemoteAccessDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrRemoteAccessDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrRemoteAccessDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
