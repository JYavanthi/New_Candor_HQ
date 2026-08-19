import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RemoteAccessServiceComponent } from './remote-access-service.component';

describe('RemoteAccessServiceComponent', () => {
  let component: RemoteAccessServiceComponent;
  let fixture: ComponentFixture<RemoteAccessServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RemoteAccessServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RemoteAccessServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
