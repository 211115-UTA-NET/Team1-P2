import { TestBed } from '@angular/core/testing';

import { UesrServiceService } from './uesr-service.service';

describe('UesrServiceService', () => {
  let service: UesrServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(UesrServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
