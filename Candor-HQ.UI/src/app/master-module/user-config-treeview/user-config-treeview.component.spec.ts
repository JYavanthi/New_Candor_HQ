import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserConfigTreeviewComponent } from './user-config-treeview.component';

describe('UserConfigTreeviewComponent', () => {
  let component: UserConfigTreeviewComponent;
  let fixture: ComponentFixture<UserConfigTreeviewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [UserConfigTreeviewComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UserConfigTreeviewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
