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
  @Input()username: string = '';
  @Input()password: string = '';
  @Input()fname: string = '';
  @Input()lname: string = '';
  
  user!: IUser_Dto;
  LoginMsg!: string;

  constructor(private bankedService: BankedService,private router: Router,private uesrServiceService: UesrServiceService) { }

  public show:boolean = false;

  //CheckLoginApi(userO: IUser_Dto)
  //{
//    if (userO.id !=0)      this.router.navigateByUrl("/userpage");     
//  }
  async CheckLogin(){
    this.user= await this.uesrServiceService.getUser(this.username,this.password);
    //alert(this.user.id);
    if (this.user.id >0)      
      this.router.navigateByUrl("/userpage");           
    else
    {  
      this.LoginMsg="User does not exists<br>try again."
//      this.show=false;  
      }
//    this.bankedService.getUser(this.username,this.password)
  //    .subscribe(retObject => this.CheckLoginApi(retObject));  
  }

  async AddNewUser(){
    this.user= {} as IUser_Dto;
    this.user.username=this.username;
    this.user.password=this.password;
    this.user.firstName=this.fname;
    this.user.lastName=this.lname;
    //debugger;
    this.user.id= await this.uesrServiceService.SaveUser(this.user);    
    if (this.user.id>0)
    {
      localStorage.setItem('userid', this.user.id.toString());
      this.router.navigateByUrl("/userpage");           
   //   var x = localStorage.getItem("userid");
    }
    else
    {
      this.LoginMsg="User Already exists<br>try again."
      alert("User Already exists");
    }    
  }
  toggleForm()
  {
    this.show = !this.show;

  }
  
  ngOnInit(): void {
  }

  
}
