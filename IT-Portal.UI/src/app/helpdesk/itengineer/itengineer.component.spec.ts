import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ItengineerComponent } from './itengineer.component';

describe('ItengineerComponent', () => {
  let component: ItengineerComponent;
  let fixture: ComponentFixture<ItengineerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ItengineerComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ItengineerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
