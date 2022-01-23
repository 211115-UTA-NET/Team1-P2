import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Expense } from './expenseInfo';
import { NewExpense } from './newExpense';
import { UserInfo } from './userInfo';

@Injectable({
  providedIn: 'root'
})
export class BankedService {

  private getExpenseUrl = '/api/Expenses/';
  private postExpenseUrl = '/api/Expenses';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  //GET user expenses
  getExpenses(): Observable<Expense[]> {
    return this.http.get<Expense[]>(this.getExpenseUrl)
  }

  //POST user expense
  addExpense(newExpense: NewExpense): Observable<NewExpense> {
    return this.http.post<NewExpense>(this.postExpenseUrl, newExpense, this.httpOptions)
  }
}
