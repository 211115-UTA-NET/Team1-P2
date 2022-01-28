import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

import { lastValueFrom, Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Expense } from './expenseInfo';
import { environment } from 'src/environments/environment';
import { IUser_Dto } from './userInfo';
import { Income } from './Income';
import { Loan } from './Loans';
import { Savings } from './Savings';
import { GraphData } from './GraphData';

@Injectable({
  providedIn: 'root'
})
export class BankedService {

  private expenseUrl = 'Expenses'
  private incomeUrl = 'Income'
  private loanUrl = 'Loans'
  private savingsUrl = 'Savings'
  private goalUrl = '';
  private reportUrl = "User/Report";

  graphInfo: number[] = [];

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

  //GET user loans
  getLoans(userId: any): Observable<Loan[]> {
    return this.http.get<Loan[]>(environment.URLBase + this.loanUrl + "/" + userId)
  }

  //POST user loan
  postLoan(loan: Loan[]): Promise<any>{
    return lastValueFrom(this.http.post<any>(environment.URLBase + this.loanUrl, loan)
//    .pipe(
//      catchError(this.handleError)
//      )
    );    
  }

  //GET user savings
  getSavings(userId: any): Observable<Savings[]> {
    return this.http.get<Savings[]>(environment.URLBase + this.savingsUrl + "/" + userId)
  }

  //POST user savings
  postSavings(savings: Savings[]): Promise<any>{
    return lastValueFrom(this.http.post<any>(environment.URLBase + this.savingsUrl, savings)
//    .pipe(
//      catchError(this.handleError)
//      )
    );    
  }

  //GET graph array
  getGraph(userId: any): Observable<any> {
    let params = new HttpParams().set('UserId', userId);
    return this.http.get(environment.URLBase + this.reportUrl, {params})
  }

  //DELETE expense
  deleteExpense(expense: number): Observable<any> {
    return this.http.delete<any>(environment.URLBase + this.expenseUrl + "/" + expense)
  }

    //DELETE income
  deleteIncome(income: number): Observable<any> {
    return this.http.delete<any>(environment.URLBase + this.incomeUrl + "/" + income)
    }

    //DELETE loan
  deleteLoan(loan: number): Observable<any> {
    return this.http.delete<any>(environment.URLBase + this.loanUrl + "/" + loan)
    }

    //DELETE savings
  deleteSavings(savings: number): Observable<any> {
    return this.http.delete<any>(environment.URLBase + this.savingsUrl + "/" + savings)
    }

  getUser(username: string,password: string): Observable<IUser_Dto> {
    return this.http.get<IUser_Dto>(environment.URLBase + `User/${username}/${password}`)
  }




}
