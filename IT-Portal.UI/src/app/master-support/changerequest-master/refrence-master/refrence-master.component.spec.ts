import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RefrenceMasterComponent } from './refrence-master.component';

describe('RefrenceMasterComponent', () => {
  let component: RefrenceMasterComponent;
  let fixture: ComponentFixture<RefrenceMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RefrenceMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RefrenceMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
