import { TestBed } from '@angular/core/testing';

import { InterceptorApiService } from './interceptor-api.service';

describe('InterceptorApiService', () => {
  let service: InterceptorApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(InterceptorApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
