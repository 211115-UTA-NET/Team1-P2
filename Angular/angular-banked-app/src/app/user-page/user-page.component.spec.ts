// Http testing module and mocking controller
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserPageComponent } from './user-page.component';

describe('UserPage Component HttpClient testing', () => {
  let httpClient: HttpClient;
  let httpTestingController: HttpTestingController;
  let component: UserPageComponent;
  let fixture: ComponentFixture<UserPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserPageComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [ HttpClientTestingModule ]
    });
    fixture = TestBed.createComponent(UserPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();

    // Inject the http service and test controller for each test.
    httpClient = TestBed.get(HttpClient);
    httpTestingController = TestBed.get(HttpTestingController);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should be false', () => {
    expect(component.createExpense).toBeFalsy;
    expect(component.createLoan).toBeFalsy;
    expect(component.createSavings).toBeFalsy;
    expect(component.createIncome).toBeFalsy;
    expect(component.getDisplay).toBeFalsy;

    expect(component.expenseGetError).toBeFalsy;
    expect(component.expensePostError).toBeFalsy;
    expect(component.expensePostErrorForm).toBeFalsy;
    expect(component.myExpense).toBeFalsy;
  });

  it('should set false', () => {
    component.clearGetErrors();
    expect(component.loanGetError).toBeFalsy;
    expect(component.expenseGetError).toBeFalsy;
    expect(component.savingsGetError).toBeFalsy;
    expect(component.incomeGetError).toBeFalsy;
  });

  it('should show income', () => {
    component.showIncome();
    expect(component.createExpense).toBeFalsy;
    expect(component.createLoan).toBeFalsy;
    expect(component.createSavings).toBeFalsy;

    expect(component.createIncome).toBeTruthy;

    expect(component.incomePostErrorForm).toBeFalsy;
    expect(component.incomePostError).toBeFalsy;
  });

  it('should show expense', () => {
    component.showExpense();
    expect(component.createExpense).toBeTruthy;

    expect(component.createLoan).toBeFalsy;
    expect(component.createSavings).toBeFalsy;
    expect(component.createIncome).toBeFalsy;
    expect(component.incomePostErrorForm).toBeFalsy;
    expect(component.incomePostError).toBeFalsy;
  });

  it('should show savings', () => {
    component.showSavings();
    expect(component.createExpense).toBeFalsy;
    expect(component.createLoan).toBeFalsy;

    expect(component.createSavings).toBeTruthy;

    expect(component.createIncome).toBeFalsy;
    expect(component.incomePostErrorForm).toBeFalsy;
    expect(component.incomePostError).toBeFalsy;
  });

  it('should show loan', () => {
    component.showLoan();
    expect(component.createExpense).toBeFalsy;

    expect(component.createLoan).toBeTruthy;

    expect(component.createSavings).toBeFalsy;
    expect(component.createIncome).toBeFalsy;
    expect(component.incomePostErrorForm).toBeFalsy;
    expect(component.incomePostError).toBeFalsy;
  });

  it('should show get expenses', () => {
    component.getExpenses();
    expect(component.getDisplay).toBeTruthy;
    expect(component.myExpense).toBeTruthy;
    
    expect(component.myIncome).toBeFalsy;
    expect(component.myLoan).toBeFalsy;
    expect(component.mySavings).toBeFalsy;
  });
});