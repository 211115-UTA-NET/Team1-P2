import { Component, Input, OnInit } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';

import { BankedService } from '../banked.service';
import { Expense } from '../expenseInfo';
import { Income } from '../Income';
import { Loan } from '../Loans';
import { Savings } from '../Savings';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})

export class UserPageComponent implements OnInit {

  //userId: string | any = localStorage.getItem("userid");
  userId: number = 1;
  createExpense: boolean = false;
  createLoan: boolean = false;
  createSavings: boolean = false;
  createIncome: boolean = false;

  graphData: number[] = [];

  expenses: Expense[] = [];
  tempExpense: Expense[] = [];
  newExpense!: Expense;
  expenseGetError: boolean = false;
  expensePostError: boolean = false;
  expensePostErrorForm: boolean = false;
  @Input() expenseId!: number;
  @Input() expenseAmount!: number;
  @Input() expenseFrequency!: number;
  @Input() expenseSeverity!: number;
  @Input() expenseDate!: string;

  incomes: Income[] = [];
  tempIncome: Income[] = [];
  newIncome!: Income;
  incomeGetError: boolean = false;
  incomePostError: boolean = false;
  incomePostErrorForm: boolean = false;
  @Input() incomeId!: number;
  @Input() incomeAmount!: number;
  @Input() paySchedule!: number;

  loans: Loan[] = [];
  tempLoan: Loan[] = [];
  newLoan!: Loan;
  loanGetError: boolean = false;
  loanPostError: boolean = false;
  loanPostErrorForm: boolean = false;
  @Input() loanName!: string;
  @Input() loanAmount!: number;
  @Input() loanInterest!: number;
  @Input() monthlyPayments!: number;

  savings: Savings[] = [];
  tempSavings: Savings[] = [];
  newSavings!: Savings;
  savingsGetError: boolean = false;
  savingsPostError: boolean = false;
  savingsPostErrorForm: boolean = false;
  @Input() savingsName!: string;
  @Input() savingsAmount!: number;
  @Input() savingsInterest!: number;
  @Input() addedMonthly!: number;

  constructor(private bankedService: BankedService) { }

  ngOnInit(): void {
  }

  clearUser(): void {
    localStorage.clear();
  }

  clearGetErrors()
  {
    this.loanGetError = false;
    this.expenseGetError = false;
    this.savingsGetError = false;
    this.incomeGetError = false;
  }

  showIncome(): void{
    this.createExpense = false;
    this.createLoan = false;
    this.createSavings = false;
    this.createIncome = true;
    this.incomePostErrorForm = false;
    this.incomePostError = false;
  }

  showExpense(): void{
    this.createExpense = true;
    this.createLoan = false;
    this.createSavings = false;
    this.createIncome = false;
    this.expensePostErrorForm = false;
    this.expensePostError = false;
  }

  showSavings(): void{
    this.createExpense = false;
    this.createLoan = false;
    this.createSavings = true;
    this.createIncome = false;
    this.savingsPostErrorForm = false;
    this.savingsPostError = false;
  }

  showLoan(): void{
    this.createExpense = false;
    this.createLoan = true;
    this.createSavings = false;
    this.createIncome = false;
    this.loanPostErrorForm = false;
    this.loanPostError = false;
  }

  getExpenses(): void
  {
    this.clearGetErrors();

    try
    {
      this.bankedService.getExpenses(this.userId)
      .subscribe(retObject => this.CheckExpenseApi(retObject));
    }
    catch //not catching
    {
      this.expenseGetError = true;
    }

    if(this.expenses.length == 0)
    {
      this.expenseGetError = true;
    }
  }
  CheckExpenseApi(retObject: Expense[]): void {
    this.incomes = [];
    this.loans = [];
    this.savings = [];
    this.expenses = retObject;
  }

  async postExpense(
    ){
      this.expensePostErrorForm = false;
      this.expensePostError = false;
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
      if (!this.userId || !this.expenseId || !this.expenseAmount || !this.expenseFrequency || !this.expenseDate)
      { 
        this.expensePostErrorForm = true;
        return; 
      }

      this.tempExpense.push(this.newExpense);

      try
      {
        this.expenses = await this.bankedService.postExpense(this.tempExpense);
      }
      catch
      {
        this.expensePostError = true;
      }
    }

    getIncomes(): void
  {
    this.clearGetErrors();

    try
    {
      this.bankedService.getIncomes(this.userId)
      .subscribe(retObject => this.CheckIncomeApi(retObject));
    }
    catch //not catching
    {
      this.incomeGetError = true;
    }

    if(this.incomes.length == 0)
    {
      this.incomeGetError = true;
    }
      
  }
  CheckIncomeApi(retObject: Income[]): void {
    this.expenses = [];
    this.loans = [];
    this.savings = [];
    this.incomes = retObject;
  }

  async postIncome(
    ){
      this.incomePostErrorForm = false;
      this.incomePostError = false;
      this.incomes = [];
      this.tempIncome = [];
      this.newIncome = {} as Income;
      this.newIncome.id = 0;
      this.newIncome.userPasswordsId = this.userId;
      this.newIncome.incomeOptions = this.incomeId;
      this.newIncome.incomeAmount = this.incomeAmount;
      this.newIncome.paySchedule = this.paySchedule;
      if (!this.userId || !this.incomeId || !this.incomeAmount || !this.paySchedule)
      { 
        this.incomePostErrorForm = true;
        return; 
      }

      this.tempIncome.push(this.newIncome);

      try
      {
        this.incomes = await this.bankedService.postIncome(this.tempIncome);
      }
      catch
      {
        this.incomePostError = true;
      }
    }

    getLoans(): void
  {
    this.clearGetErrors();

    try
    {
      this.bankedService.getLoans(this.userId)
      .subscribe(retObject => this.CheckLoanApi(retObject));
    }
    catch //not catching
    {
      this.loanGetError = true;
    }

    if(this.loans.length == 0)
    {
      this.loanGetError = true;
    }
      
  }
  CheckLoanApi(retObject: Loan[]): void {
    this.incomes = [];
    this.expenses = [];
    this.savings = [];
    this.loans = retObject;
  }

  async postLoan(
    ){
      this.loanPostErrorForm = false;
      this.loanPostError = false;
      this.loans = [];
      this.tempLoan = [];
      this.newLoan = {} as Loan;
      this.newLoan.id = 0;
      this.newLoan.userPasswordId = this.userId;
      this.newLoan.loanName = this.loanName;
      this.newLoan.loanAmount = this.loanAmount;
      this.newLoan.loanInterest = this.loanInterest;
      this.newLoan.monthlyPayments = this.monthlyPayments;
      if (!this.userId || !this.loanName || !this.loanAmount || !this.loanInterest || !this.monthlyPayments)
      {
        this.loanPostErrorForm = true;
        return;
      }

      this.tempLoan.push(this.newLoan);

      try
      {
        this.loans = await this.bankedService.postLoan(this.tempLoan);
      }
      catch
      {
        this.loanPostError = true;
      }
    }

    getSavings(): void
  {
    this.clearGetErrors();

    try
    {
      this.bankedService.getSavings(this.userId)
      .subscribe(retObject => this.CheckSavingsApi(retObject));
    }
    catch //not catching
    {
      this.savingsGetError = true;
    }

    if(this.savings.length == 0)
    {
      this.savingsGetError = true;
    }
  }
  CheckSavingsApi(retObject: Savings[]): void {
    this.expenses = [];
    this.loans = [];
    this.incomes = [];
    this.savings = retObject;
  }

  async postSavings(
    ){
      this.savingsPostErrorForm = false;
      this.savingsPostError = false;
      this.savings = [];
      this.tempSavings = [];
      this.newSavings = {} as Savings;
      this.newSavings.id = 0;
      this.newSavings.userPassword = this.userId;
      this.newSavings.savingsName = this.loanName;
      this.newSavings.savingsAmount = this.loanAmount;
      this.newSavings.savingsInterest = this.loanInterest;
      this.newSavings.savingsAddedMonthly = this.monthlyPayments;
      if (!this.userId || !this.savingsName || !this.savingsAmount || !this.savingsInterest || !this.addedMonthly)
      { 
        this.savingsPostErrorForm = true;
        return; 
      }

      this.tempSavings.push(this.newSavings);

      try
      {
        this.savings = await this.bankedService.postSavings(this.tempSavings);
      }
      catch
      {
        this.savingsPostError = true;
      }
    }

    getGraphData(): void
  {
      this.bankedService.getGraph(this.userId)
      .subscribe(retObject => this.CheckGraphApi(retObject));
  }
  CheckGraphApi(retObject: Array<number>): void {
    this.graphData = retObject;
  }
}