import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-signin-page',
  templateUrl: './signin-page.component.html',
  styleUrls: ['./signin-page.component.css']
})
export class SigninPageComponent implements OnInit {

  constructor() { }

  public show:boolean = false;

  toggleForm()
  {
    this.show = !this.show;
  }
  
  ngOnInit(): void {
  }

}
