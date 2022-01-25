import { Injectable } from '@angular/core';
import { HttpClient,HttpResponse,HttpErrorResponse  } from '@angular/common/http';
import { Observable, throwError,lastValueFrom } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { IUser_Dto } from './userInfo';

@Injectable({
  providedIn: 'root'
})
export class UesrServiceService {

  constructor(private http: HttpClient) { }

  getUser(username: string,password: string): Promise<IUser_Dto>{
    return lastValueFrom(this.http.get<IUser_Dto>(`https://localhost:7106/api/User/${username}/${password}`)
//    .pipe(
//      catchError(this.handleError)
//      )
    );    
  }
  //this.http.post<Hero>(this.heroesUrl, hero, httpOptions)
  SaveUser(user: IUser_Dto): Promise<any>{
    return lastValueFrom(this.http.post<any>(`https://localhost:7106/api/User`,user)
//    .pipe(
//      catchError(this.handleError)
//      )
    );    
  }

  handleError(error: HttpErrorResponse){
    console.log("lalalalalalalala");
    return throwError(error);
    }
}
