import { TestBed } from '@angular/core/testing';

import { StageStatusCodeService } from './stage-status-code.service';

describe('StageStatusCodeService', () => {
  let service: StageStatusCodeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(StageStatusCodeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
