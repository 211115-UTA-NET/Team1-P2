import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Expense } from './expenseInfo';
import { environment } from 'src/environments/environment';
import { IUser_Dto } from './userInfo';

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
  addExpense(expense: Expense): Observable<Expense> {
    return this.http.post<Expense>(this.expenseUrl, expense, this.httpOptions)
  }


  getUser(username: string,password: string): Observable<IUser_Dto> {
    return this.http.get<IUser_Dto>(environment.URLBase + `User/${username}/${password}`)
  }




}
