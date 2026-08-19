import { TestBed } from '@angular/core/testing';

import { UserInfoSerService } from './user-info-ser.service';

describe('UserInfoSerService', () => {
  let service: UserInfoSerService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UserInfoSerService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
