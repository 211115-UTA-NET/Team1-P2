import { Component, Input, OnInit } from '@angular/core';

import { BankedService } from '../banked.service';
import { Expense } from '../expenseInfo';
import { ThisReceiver } from '@angular/compiler';
import { Income } from '../Income';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})

export class UserPageComponent implements OnInit {

  userId: string | any = localStorage.getItem("userid");

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

  constructor(private bankedService: BankedService) { }

  ngOnInit(): void {
  }

  getExpenses(): void
  {
      this.bankedService.getExpenses(this.userId)
      //.subscribe(expenses => this.expenses = expenses);
      .subscribe(retObject => this.CheckExpenseApi(retObject));
  }
  CheckExpenseApi(retObject: Expense[]): void {
    this.incomes = [];
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
      //.subscribe(expenses => this.expenses = expenses);
      .subscribe(retObject => this.CheckIncomeApi(retObject));
  }
  CheckIncomeApi(retObject: Income[]): void {
    this.expenses = [];
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
}