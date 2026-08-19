import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AccessFolderServiceComponent } from './access-folder-service.component';

describe('AccessFolderServiceComponent', () => {
  let component: AccessFolderServiceComponent;
  let fixture: ComponentFixture<AccessFolderServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AccessFolderServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AccessFolderServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
