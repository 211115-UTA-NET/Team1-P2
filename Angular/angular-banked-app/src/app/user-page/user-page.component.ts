import { Component, Input, OnInit } from '@angular/core';

import { BankedService } from '../banked.service';
import { Expense } from '../expenseInfo';
import { ThisReceiver } from '@angular/compiler';
import { Income } from '../Income';
import { Loan } from '../Loans';
import { Savings } from '../Savings';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})

export class UserPageComponent implements OnInit {

  userId: string | any = localStorage.getItem("userid");
  createExpense: boolean = false;
  createLoan: boolean = false;
  createSavings: boolean = false;
  createIncome: boolean = false;

  expenses: Expense[] = [];
  tempExpense: Expense[] = [];
  newExpense!: Expense;
  @Input() expenseId: number = -1;
  @Input() expenseAmount: number = -1;
  @Input() expenseFrequency: number = -1;
  @Input() expenseSeverity: number = -1;
  @Input() expenseDate: string = '';

  incomes: Income[] = [];
  tempIncome: Income[] = [];
  newIncome!: Income;
  @Input() incomeId: number = -1;
  @Input() incomeAmount: number = -1;
  @Input() paySchedule: number = -1;

  loans: Loan[] = [];
  tempLoan: Loan[] = [];
  newLoan!: Loan;
  @Input() loanName: string = '';
  @Input() loanAmount: number = -1;
  @Input() loanInterest: number = -1;
  @Input() monthlyPayments: number = -1;

  savings: Savings[] = [];
  tempSavings: Savings[] = [];
  newSavings!: Savings;
  @Input() savingsName: string = '';
  @Input() savingsAmount: number = -1;
  @Input() savingsInterest: number = -1;
  @Input() addedMonthly: number = -1;

  constructor(private bankedService: BankedService) { }

  ngOnInit(): void {
  }

  showIncome(): void{
    this.createExpense = false;
    this.createLoan = false;
    this.createSavings = false;
    this.createIncome = true;
  }

  showExpense(): void{
    this.createExpense = true;
    this.createLoan = false;
    this.createSavings = false;
    this.createIncome = false;
  }

  showSavings(): void{
    this.createExpense = false;
    this.createLoan = false;
    this.createSavings = true;
    this.createIncome = false;
  }

  showLoan(): void{
    this.createExpense = false;
    this.createLoan = true;
    this.createSavings = false;
    this.createIncome = false;
  }

  getExpenses(): void
  {
      this.bankedService.getExpenses(this.userId)
      .subscribe(retObject => this.CheckExpenseApi(retObject));
  }
  CheckExpenseApi(retObject: Expense[]): void {
    this.incomes = [];
    this.loans = [];
    this.savings = [];
    this.expenses = retObject;
  }

  async postExpense(
    ){
      this.expenses = [];
      this.tempExpense = [];
      this.newExpense = {} as Expense;
      this.newExpense.id = 0;
      this.newExpense.userPassId = this.userId;
      this.newExpense.userOptionsId = this.expenseId;
      this.newExpense.expenseAmount = this.expenseAmount;
      this.newExpense.expenseFrequency = this.expenseFrequency;
      this.newExpense.expenseEnding = this.expenseDate;
      this.newExpense.priority = this.expenseSeverity;
      if (!this.userId || this.expenseId == -1 || this.expenseAmount == -1 || this.expenseFrequency == -1 || !this.expenseDate)
      { return; }

      this.tempExpense.push(this.newExpense);

      this.expenses = await this.bankedService.postExpense(this.tempExpense);
    }

    getIncomes(): void
  {
      this.bankedService.getIncomes(this.userId)
      .subscribe(retObject => this.CheckIncomeApi(retObject));
  }
  CheckIncomeApi(retObject: Income[]): void {
    this.expenses = [];
    this.loans = [];
    this.savings = [];
    this.incomes = retObject;
  }

  async postIncome(
    ){
      this.incomes = [];
      this.tempIncome = [];
      this.newIncome = {} as Income;
      this.newIncome.id = 0;
      this.newIncome.userPasswordsId = this.userId;
      this.newIncome.incomeOptions = this.incomeId;
      this.newIncome.incomeAmount = this.incomeAmount;
      this.newIncome.paySchedule = this.paySchedule;
      if (!this.userId || this.incomeId == -1 || this.incomeAmount == -1 || this.paySchedule == -1)
      { return; }

      this.tempIncome.push(this.newIncome);

      this.incomes = await this.bankedService.postIncome(this.tempIncome);
    }

    getLoans(): void
  {
      this.bankedService.getLoans(this.userId)
        .subscribe(retObject => this.CheckLoanApi(retObject));
  }
  CheckLoanApi(retObject: Loan[]): void {
    this.incomes = [];
    this.expenses = [];
    this.savings = [];
    this.loans = retObject;
  }

  async postLoan(
    ){
      this.loans = [];
      this.tempLoan = [];
      this.newLoan = {} as Loan;
      this.newLoan.id = 0;
      this.newLoan.userPasswordId = this.userId;
      this.newLoan.loanName = this.loanName;
      this.newLoan.loanAmount = this.loanAmount;
      this.newLoan.loanInterest = this.loanInterest;
      this.newLoan.monthlyPayments = this.monthlyPayments;
      if (!this.userId || !this.loanName || this.loanAmount == -1 || this.loanInterest == -1 || this.monthlyPayments == -1)
      { return; }

      this.tempLoan.push(this.newLoan);

      this.loans = await this.bankedService.postLoan(this.tempLoan);
    }

    getSavings(): void
  {
      this.bankedService.getSavings(this.userId)
      .subscribe(retObject => this.CheckSavingsApi(retObject));
  }
  CheckSavingsApi(retObject: Savings[]): void {
    this.expenses = [];
    this.loans = [];
    this.incomes = [];
    this.savings = retObject;
  }

  async postSavings(
    ){
      this.savings = [];
      this.tempSavings = [];
      this.newSavings = {} as Savings;
      this.newSavings.id = 0;
      this.newSavings.userPassword = this.userId;
      this.newSavings.savingsName = this.loanName;
      this.newSavings.savingsAmount = this.loanAmount;
      this.newSavings.savingsInterest = this.loanInterest;
      this.newSavings.savingsAddedMonthly = this.monthlyPayments;
      if (!this.userId || !this.savingsName || this.savingsAmount == -1 || this.savingsInterest == -1 || this.addedMonthly == -1)
      { return; }

      this.tempSavings.push(this.newSavings);

      this.savings = await this.bankedService.postSavings(this.tempSavings);
    }
}