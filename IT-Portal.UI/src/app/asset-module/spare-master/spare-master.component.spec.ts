import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SpareMasterComponent } from './spare-master.component';

describe('SpareMasterComponent', () => {
  let component: SpareMasterComponent;
  let fixture: ComponentFixture<SpareMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SpareMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SpareMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
