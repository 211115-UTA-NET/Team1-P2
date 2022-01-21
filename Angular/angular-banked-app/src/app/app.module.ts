import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { NgChartsModule } from 'ng2-charts';

import { AppComponent } from './app.component';
import { UserPageComponent } from './user-page/user-page.component';

import { RouterModule } from '@angular/router';
import { SigninPageComponent } from './signin-page/signin-page.component';
import { TopBarComponent } from './top-bar/top-bar.component';

@NgModule({
  declarations: [
    AppComponent,
    UserPageComponent,
    SigninPageComponent,
    TopBarComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    NgChartsModule,
    RouterModule.forRoot([
      { path: '', component: SigninPageComponent },
      { path: 'userpage', component: UserPageComponent },
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
