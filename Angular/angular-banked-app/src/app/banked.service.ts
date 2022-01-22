import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Expense } from './expenseInfo';
import { NewExpense } from './newExpense';

@Injectable({
  providedIn: 'root'
})
export class BankedService {

  private expenseUrl = '{EXPENSES URL}'

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  //GET user expenses
  getExpenses(): Observable<Expense[]> {
    return this.http.get<Expense[]>(this.expenseUrl)
  }

  //POST user expense
  addExpense(newExpense: NewExpense): Observable<NewExpense> {
    return this.http.post<NewExpense>(this.expenseUrl, newExpense, this.httpOptions)
  }
}
