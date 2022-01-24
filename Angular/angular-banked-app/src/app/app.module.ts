import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
<<<<<<< HEAD
import { HttpClientModule } from '@angular/common/http';
=======

>>>>>>> ShaulTestNew

import { AppComponent } from './app.component';
import { UserPageComponent } from './user-page/user-page.component';

import { RouterModule } from '@angular/router';
import { SigninPageComponent } from './signin-page/signin-page.component';
import { TopBarComponent } from './top-bar/top-bar.component';
<<<<<<< HEAD

=======
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { InterceptorService } from './interceptor.service';
>>>>>>> ShaulTestNew
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
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: SigninPageComponent },
      { path: 'userpage', component: UserPageComponent },
    ])
  ],
<<<<<<< HEAD
  providers: [],
=======
  providers: [
    {
    provide: HTTP_INTERCEPTORS,
    useClass: InterceptorService,
    multi: true
    }
  ],
>>>>>>> ShaulTestNew
  bootstrap: [AppComponent]
})
export class AppModule { }
