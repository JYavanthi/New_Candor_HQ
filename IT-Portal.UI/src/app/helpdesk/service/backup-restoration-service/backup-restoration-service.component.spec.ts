import { ComponentFixture, TestBed } from '@angular/core/testing';

import { BackupRestorationServiceComponent } from './backup-restoration-service.component';

describe('BackupRestorationServiceComponent', () => {
  let component: BackupRestorationServiceComponent;
  let fixture: ComponentFixture<BackupRestorationServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [BackupRestorationServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(BackupRestorationServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
