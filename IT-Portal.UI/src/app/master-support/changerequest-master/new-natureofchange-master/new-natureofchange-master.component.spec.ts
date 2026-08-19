import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewNatureofchangeMasterComponent } from './new-natureofchange-master.component';

describe('NewNatureofchangeMasterComponent', () => {
  let component: NewNatureofchangeMasterComponent;
  let fixture: ComponentFixture<NewNatureofchangeMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewNatureofchangeMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewNatureofchangeMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
