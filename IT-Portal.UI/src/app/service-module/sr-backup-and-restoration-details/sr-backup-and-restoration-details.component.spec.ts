import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrBackupAndRestorationDetailsComponent } from './sr-backup-and-restoration-details.component';

describe('SrBackupAndRestorationDetailsComponent', () => {
  let component: SrBackupAndRestorationDetailsComponent;
  let fixture: ComponentFixture<SrBackupAndRestorationDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrBackupAndRestorationDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrBackupAndRestorationDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
