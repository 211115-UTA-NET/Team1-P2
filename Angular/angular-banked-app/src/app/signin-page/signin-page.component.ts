import { Component, OnInit } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';

@Component({
  selector: 'app-signin-page',
  templateUrl: './signin-page.component.html',
  styleUrls: ['./signin-page.component.css']
})

@Injectable()
export class SigninPageComponent implements OnInit {

  constructor(private http: HttpClient) { }

  public show:boolean = false;

  toggleForm()
  {
    this.show = !this.show;
  }
  
  ngOnInit(): void {
  }

}
