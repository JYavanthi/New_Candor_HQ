import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProTemplateViewComponent } from './pro-template-view.component';

describe('ProTemplateViewComponent', () => {
  let component: ProTemplateViewComponent;
  let fixture: ComponentFixture<ProTemplateViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ProTemplateViewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ProTemplateViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
