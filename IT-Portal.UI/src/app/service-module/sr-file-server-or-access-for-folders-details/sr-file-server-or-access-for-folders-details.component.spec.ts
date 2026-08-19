import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SrFileServerOrAccessForFoldersDetailsComponent } from './sr-file-server-or-access-for-folders-details.component';

describe('SrFileServerOrAccessForFoldersDetailsComponent', () => {
  let component: SrFileServerOrAccessForFoldersDetailsComponent;
  let fixture: ComponentFixture<SrFileServerOrAccessForFoldersDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SrFileServerOrAccessForFoldersDetailsComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SrFileServerOrAccessForFoldersDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
