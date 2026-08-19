import { ComponentFixture, TestBed } from '@angular/core/testing';

import { VirtualmeetServiceComponent } from './virtualmeet-service.component';

describe('VirtualmeetServiceComponent', () => {
  let component: VirtualmeetServiceComponent;
  let fixture: ComponentFixture<VirtualmeetServiceComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [VirtualmeetServiceComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(VirtualmeetServiceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
