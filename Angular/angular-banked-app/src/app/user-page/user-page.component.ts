import { Component, Input, OnInit } from '@angular/core';
<<<<<<< HEAD
import { FormControl } from '@angular/forms';
=======
>>>>>>> ShaulTestNew

import { BankedService } from '../banked.service';
import { EXPENSES } from '../test-expenses';
import { Expense } from '../expenseInfo';
<<<<<<< HEAD
import { NewExpense } from '../newExpense';
import { UserInfo } from '../userInfo';
import { userInfo } from 'os';
=======
>>>>>>> ShaulTestNew

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})

export class UserPageComponent implements OnInit {
  //expenses = EXPENSES;

  expenses: Expense[] = [];
<<<<<<< HEAD
  createExpense: NewExpense[] = [];
=======
>>>>>>> ShaulTestNew

  @Input() expense?: Expense;

  constructor(private bankedService: BankedService) { }

  ngOnInit(): void {
    this.getExpenses();
  }

  getExpenses(): void
  {
<<<<<<< HEAD
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
=======
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
>>>>>>> ShaulTestNew
}
