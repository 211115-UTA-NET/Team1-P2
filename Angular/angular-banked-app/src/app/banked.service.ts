import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { lastValueFrom, Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Expense } from './expenseInfo';
import { environment } from 'src/environments/environment';
import { IUser_Dto } from './userInfo';
import { Income } from './Income';

@Injectable({
  providedIn: 'root'
})
export class BankedService {

  private expenseUrl = 'Expenses'
  private incomeUrl = 'Income'

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor(private http: HttpClient) { }

  //GET user expenses
  getExpenses(userId: any): Observable<Expense[]> {
    return this.http.get<Expense[]>(environment.URLBase + this.expenseUrl + "/" + userId)
  }

  //POST user expense
  postExpense(expense: Expense[]): Promise<any>{
    return lastValueFrom(this.http.post<any>(environment.URLBase + this.expenseUrl, expense)
//    .pipe(
//      catchError(this.handleError)
//      )
    );    
  }

  //GET user incomes
  getIncomes(userId: any): Observable<Income[]> {
    return this.http.get<Income[]>(environment.URLBase + this.incomeUrl + "/" + userId)
  }

  //POST user income
  postIncome(income: Income[]): Promise<any>{
    return lastValueFrom(this.http.post<any>(environment.URLBase + this.incomeUrl, income)
//    .pipe(
//      catchError(this.handleError)
//      )
    );    
  }


  //getUser(username: string,password: string): Observable<IUser_Dto> {
  //  return this.http.get<IUser_Dto>(environment.URLBase + `User/${username}/${password}`)
  //}




}
