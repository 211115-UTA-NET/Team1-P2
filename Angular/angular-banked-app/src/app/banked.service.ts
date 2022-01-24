import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Expense } from './expenseInfo';
<<<<<<< HEAD
import { NewExpense } from './newExpense';
import { UserInfo } from './userInfo';
=======
import { environment } from 'src/environments/environment';
import { IUser_Dto } from './userInfo';
>>>>>>> ShaulTestNew

@Injectable({
  providedIn: 'root'
})
export class BankedService {

<<<<<<< HEAD
  private getExpenseUrl = '/api/Expenses/';
  private postExpenseUrl = '/api/Expenses';
=======
  private expenseUrl = '{EXPENSES URL}'
>>>>>>> ShaulTestNew

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  //GET user expenses
  getExpenses(): Observable<Expense[]> {
<<<<<<< HEAD
    return this.http.get<Expense[]>(this.getExpenseUrl)
  }

  //POST user expense
  addExpense(newExpense: NewExpense): Observable<NewExpense> {
    return this.http.post<NewExpense>(this.postExpenseUrl, newExpense, this.httpOptions)
  }
=======
    return this.http.get<Expense[]>(this.expenseUrl)
  }

  //POST user expense
  addExpense(expense: Expense): Observable<Expense> {
    return this.http.post<Expense>(this.expenseUrl, expense, this.httpOptions)
  }


  getUser(username: string,password: string): Observable<IUser_Dto> {
    return this.http.get<IUser_Dto>(environment.URLBase + `User/${username}/${password}`)
  }




>>>>>>> ShaulTestNew
}
