import { Injectable } from '@angular/core';
import { IUser_Dto } from './UserDto';
import { HttpClient,HttpResponse } from '@angular/common/http';
import { Observable, throwError,lastValueFrom } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';


@Injectable({
  providedIn: 'root'
})
export class UesrServiceService {

  constructor(private http: HttpClient) { }

  getUser(username: string,password: string): Promise<IUser_Dto>{
    return lastValueFrom(this.http.get<IUser_Dto>(`https://localhost:7106/api/User/${username}/${password}`));    
  }
}
