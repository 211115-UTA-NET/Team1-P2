import { Component, OnInit, Input  } from '@angular/core';
import { Injectable } from '@angular/core';
import { HttpClient,HttpResponse } from '@angular/common/http';
import { Observable, throwError,lastValueFrom } from 'rxjs';
import { catchError, retry } from 'rxjs/operators';
import { UesrServiceService } from '../uesr-service.service';
import { IUser_Dto } from '../UserDto';

@Component({
  selector: 'app-signin-page',
  templateUrl: './signin-page.component.html',
  styleUrls: ['./signin-page.component.css']
})

@Injectable()
export class SigninPageComponent implements OnInit {

  
  constructor(private uesrServiceService: UesrServiceService) { }
  user!: IUser_Dto;
  public show:boolean = false;
   
   @Input()username: string = '';
   @Input()password: string = '';
  async toggleForm()
  {
    alert(this.username);
    
    var obj = {};
    this.user=await this.uesrServiceService.getUser(this.username,this.password);
    
    if (this.user.id !=0)
    alert(this.user.lastName)
    
    
    this.show = !this.show;
 
 
  }
  
  ngOnInit(): void {
  }

}

