import { Component, Input, OnInit } from '@angular/core';

import { BankedService } from '../banked.service';
import { EXPENSES } from '../test-expenses';
import { Expense } from '../expenseInfo';
import { NewExpense } from '../newExpense';
import { ThisReceiver } from '@angular/compiler';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})

export class UserPageComponent implements OnInit {
  //expenses = EXPENSES;

  expenses: Expense[] = [];

  @Input() expense?: Expense;

  @Input() expenseName: string = '';
  @Input() expenseFrequency: string = '';
  @Input() expenseSeverity: string = '';

  userId = localStorage.getItem("userid");

  newExpense!: NewExpense;

  constructor(private bankedService: BankedService) { }

  ngOnInit(): void {
    this.getExpenses();
  }

  getExpenses(): void
  {
      this.bankedService.getExpenses()
      .subscribe(expenses => this.expenses = expenses);
  }

  add(
    ): void {
      this.newExpense = {} as NewExpense;
      this.newExpense.id = this.userId;
      this.newExpense.name = this.expenseName;
      this.newExpense.frequency = this.expenseFrequency;
      this.newExpense.priority = this.expenseSeverity;
      if (!this.expenseName || !this.expenseFrequency || !this.expenseSeverity) { return; }
    this.bankedService.addExpense(this.newExpense)
      .subscribe(expense => {
        this.expenses.push(expense);
      });

    }
}
