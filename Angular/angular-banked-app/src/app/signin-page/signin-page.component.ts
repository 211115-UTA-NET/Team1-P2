import { Component, OnInit,Input } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient,HttpResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { BankedService } from '../banked.service';
import { IUser_Dto } from '../userInfo';
import { Router } from '@angular/router';
import { UesrServiceService } from '../userservice.service';
@Component({
  selector: 'app-signin-page',
  templateUrl: './signin-page.component.html',
  styleUrls: ['./signin-page.component.css']
})



@Injectable()
export class SigninPageComponent implements OnInit {
  //private http: HttpClient
  @Input()username!: string;
  @Input()password!: string;
  @Input()fname!: string;
  @Input()lname!: string;
  
  user!: IUser_Dto;
  LoginMsg!: string;
  createError: boolean = false;
  loginError: boolean = false;
  createSuccess: boolean = false;

  constructor(
    private bankedService: BankedService,
    private router: Router,
    private uesrServiceService: UesrServiceService
    ) { }

  public show:boolean = false;

  async CheckLogin(){
    this.loginError = false;
    this.createError = false;
    this.user = await this.uesrServiceService.getUser(this.username,this.password);
    if (this.user.id > 0 && this.username && this.password)
    {
      localStorage.setItem('fName', this.user.firstName.toString());
      localStorage.setItem('lName', this.user.firstName.toString());
      localStorage.setItem('userid', this.user.id.toString());
      this.router.navigateByUrl("/userpage");
    }          
    else
    {  
      this.loginError = true; 
      this.createError = false;
    }
  }

  async AddNewUser(){
    this.createError = false;
    this.createSuccess = false;
    this.user= {} as IUser_Dto;
    this.user.username=this.username;
    this.user.password=this.password;
    this.user.firstName=this.fname;
    this.user.lastName=this.lname;
    //debugger;
    this.user.id= await this.uesrServiceService.SaveUser(this.user);    
    if (this.user.id > 0 && this.user.username && this.user.password && this.user.firstName && this.user.lastName)
    {
      this.show = !this.show;
      localStorage.setItem('userid', this.user.id.toString());          
      var x = localStorage.getItem("userid");
      this.createSuccess = true;
    }
    else
    {
      this.createError = true;
    }
  }
  toggleForm()
  {
    this.show = !this.show;
  }
  
  ngOnInit(): void {
  }
}