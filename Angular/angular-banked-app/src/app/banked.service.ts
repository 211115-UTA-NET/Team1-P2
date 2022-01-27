import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { lastValueFrom, Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Expense } from './expenseInfo';
import { environment } from 'src/environments/environment';
import { IUser_Dto } from './userInfo';
import { Income } from './Income';
import { Loan } from './Loans';
import { Savings } from './Savings';
import { Goal } from './Goal';

@Injectable({
  providedIn: 'root'
})
export class BankedService {

  private expenseUrl = 'Expenses'
  private incomeUrl = 'Income'
  private loanUrl = 'Loans'
  private savingsUrl = 'Savings'
  private graphUrl = '';
  private goalUrl = '';

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
  getGraph(userId: any): Observable<Array<number>> {
    return this.http.get<Array<number>>(environment.URLBase + this.graphUrl + "/" + userId)
  }

  //GET savings goal
  getGoal(userId: any): Observable<Goal[]> {
    return this.http.get<Goal[]>(environment.URLBase + this.goalUrl + "/" + userId)
  }

  //DELETE expense
  deleteExpense(userId: any, expense: number): Promise<any> {
    return lastValueFrom(this.http.delete<any>(environment.URLBase + this.expenseUrl + "/" + userId + "/" + expense)
    );}

    //DELETE income
  deleteIncome(userId: any, income: number): Promise<any> {
    return lastValueFrom(this.http.delete<any>(environment.URLBase + this.incomeUrl + "/" + userId + "/" + income)
    );}

    //DELETE loan
  deleteLoan(userId: any, loan: number): Promise<any> {
    return lastValueFrom(this.http.delete<any>(environment.URLBase + this.loanUrl + "/" + userId + "/" + loan)
    );}

    //DELETE savings
  deleteSavings(userId: any, savings: number): Promise<any> {
    return lastValueFrom(this.http.delete<any>(environment.URLBase + this.savingsUrl + "/" + userId + "/" + savings)
    );}

  getUser(username: string,password: string): Observable<IUser_Dto> {
    return this.http.get<IUser_Dto>(environment.URLBase + `User/${username}/${password}`)
  }




}
