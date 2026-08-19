import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewslamasterComponent } from './newslamaster.component';

describe('NewslamasterComponent', () => {
  let component: NewslamasterComponent;
  let fixture: ComponentFixture<NewslamasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewslamasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewslamasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
