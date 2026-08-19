import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NewsupportmasterComponent } from './newsupportmaster.component';

describe('NewsupportmasterComponent', () => {
  let component: NewsupportmasterComponent;
  let fixture: ComponentFixture<NewsupportmasterComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [NewsupportmasterComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NewsupportmasterComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
