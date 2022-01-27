// Http testing module and mocking controller
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { TestBed } from '@angular/core/testing';

import { BankedService } from './banked.service';


describe('BankedService HttpClient testing', () => {
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;
  let service: BankedService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });
    service = TestBed.inject(BankedService);

    // Inject the http service and test controller for each test.
    httpClient = TestBed.get(HttpClient);
    httpTestingController = TestBed.get(HttpTestingController);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should get expenses', () => {
    service.getExpenses(1);
    expect(service.getExpenses).toBeTruthy();
  });

  it('should get incomes', () => {
    service.getIncomes(1);
    expect(service.getIncomes).toBeTruthy();
  });

  it('should get Loans', () => {
    service.getLoans(1);
    expect(service.getLoans).toBeTruthy();
  });

  it('should get Savings', () => {
    service.getSavings(1);
    expect(service.getSavings).toBeTruthy();
  });

  it('should get Graph', () => {
    service.getGraph(1);
    expect(service.getGraph).toBeTruthy();
  });

  it('should get Goal', () => {
    service.getGoal(1);
    expect(service.getGoal).toBeTruthy();
  });
});