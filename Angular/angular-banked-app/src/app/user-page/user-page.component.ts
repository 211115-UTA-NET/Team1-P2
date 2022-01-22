import { Component, Input, OnInit } from '@angular/core';

import { BankedService } from '../banked.service';
import { EXPENSES } from '../test-expenses';
import { Expense } from '../expenseInfo';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})

export class UserPageComponent implements OnInit {
  //expenses = EXPENSES;

  expenses: Expense[] = [];

  @Input() expense?: Expense;

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
    id: number,
    name: string,
    frequency: number,
    priority: number,
    ): void {
    if (!name || !frequency || !priority) { return; }
    this.bankedService.addExpense({ name, frequency, priority } as Expense)
      .subscribe(expense => {
        this.expenses.push(expense);
      });
  }
}
