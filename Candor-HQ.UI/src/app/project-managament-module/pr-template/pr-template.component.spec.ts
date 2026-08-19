import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PrTemplateComponent } from './pr-template.component';

describe('PrTemplateComponent', () => {
  let component: PrTemplateComponent;
  let fixture: ComponentFixture<PrTemplateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [PrTemplateComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(PrTemplateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
