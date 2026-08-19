import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExternalDriveAcessServiceComponent } from './external-drive-acess-service.component';

describe('ExternalDriveAcessServiceComponent', () => {
  let component: ExternalDriveAcessServiceComponent;
  let fixture: ComponentFixture<ExternalDriveAcessServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ExternalDriveAcessServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExternalDriveAcessServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
