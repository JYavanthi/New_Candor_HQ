import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AntivirusServiceComponent } from './antivirus-service.component';

describe('AntivirusServiceComponent', () => {
  let component: AntivirusServiceComponent;
  let fixture: ComponentFixture<AntivirusServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AntivirusServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AntivirusServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
