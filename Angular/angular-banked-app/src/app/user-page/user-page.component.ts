import { Component, Input, OnInit } from '@angular/core';
import { FormControl } from '@angular/forms';

import { BankedService } from '../banked.service';
import { EXPENSES } from '../test-expenses';
import { Expense } from '../expenseInfo';
import { NewExpense } from '../newExpense';
import { UserInfo } from '../userInfo';
import { userInfo } from 'os';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})

export class UserPageComponent implements OnInit {
  //expenses = EXPENSES;

  expenses: Expense[] = [];
  createExpense: NewExpense[] = [];

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

  newExpense(
    name: string,
    frequency: string,
    priority: string,
    ): void {
    if (!name || !frequency || !priority) { return; }
    this.bankedService.addExpense({ name, frequency, priority } as NewExpense)
      .subscribe(newExpense => {
        this.createExpense.push(newExpense);
      });
  }

  createNewExpense(): void {
  }
}
