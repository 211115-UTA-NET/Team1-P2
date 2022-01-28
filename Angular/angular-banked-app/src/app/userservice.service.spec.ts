// Http testing module and mocking controller
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { TestBed } from '@angular/core/testing';

import { UesrServiceService } from './userservice.service';


describe('UserService HttpClient testing', () => {
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;
  let service: UesrServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });
    service = TestBed.inject(UesrServiceService);

    // Inject the http service and test controller for each test.
    httpClient = TestBed.get(HttpClient);
    httpTestingController = TestBed.get(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
