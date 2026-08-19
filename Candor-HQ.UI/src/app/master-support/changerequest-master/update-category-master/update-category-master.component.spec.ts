import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UpdateCategoryMasterComponent } from './update-category-master.component';

describe('UpdateCategoryMasterComponent', () => {
  let component: UpdateCategoryMasterComponent;
  let fixture: ComponentFixture<UpdateCategoryMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UpdateCategoryMasterComponent]
    })
      .compileComponents();

    fixture = TestBed.createComponent(UpdateCategoryMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
