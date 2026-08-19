import { TestBed } from '@angular/core/testing';

import { PasscrdataService } from './passcrdata.service';

describe('PasscrdataService', () => {
  let service: PasscrdataService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PasscrdataService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
