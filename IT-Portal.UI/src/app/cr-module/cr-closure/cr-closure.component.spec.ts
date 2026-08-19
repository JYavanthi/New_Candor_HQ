import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CrClosureComponent } from './cr-closure.component';

describe('CrClosureComponent', () => {
  let component: CrClosureComponent;
  let fixture: ComponentFixture<CrClosureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [CrClosureComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CrClosureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
