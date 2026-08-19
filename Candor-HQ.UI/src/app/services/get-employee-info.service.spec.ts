import { TestBed } from '@angular/core/testing';

import { GetEmployeeInfoService } from './get-employee-info.service';

describe('GetEmployeeInfoService', () => {
  let service: GetEmployeeInfoService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GetEmployeeInfoService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
