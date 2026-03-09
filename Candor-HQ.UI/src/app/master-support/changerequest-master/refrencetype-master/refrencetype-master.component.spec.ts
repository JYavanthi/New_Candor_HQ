import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RefrencetypeMasterComponent } from './refrencetype-master.component';

describe('RefrencetypeMasterComponent', () => {
  let component: RefrencetypeMasterComponent;
  let fixture: ComponentFixture<RefrencetypeMasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [RefrencetypeMasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(RefrencetypeMasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
