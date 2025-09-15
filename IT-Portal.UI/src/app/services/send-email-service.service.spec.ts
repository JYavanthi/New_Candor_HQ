import { TestBed } from '@angular/core/testing';

import { SendEmailServiceService } from './send-email-service.service';

describe('SendEmailServiceService', () => {
  let service: SendEmailServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SendEmailServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
