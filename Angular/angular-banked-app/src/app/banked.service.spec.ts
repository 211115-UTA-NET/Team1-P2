import { TestBed } from '@angular/core/testing';

import { BankedService } from './banked.service';

describe('BankedService', () => {
  let service: BankedService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BankedService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
