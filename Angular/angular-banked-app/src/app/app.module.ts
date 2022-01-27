import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { UserPageComponent } from './user-page/user-page.component';

import { RouterModule } from '@angular/router';
import { SigninPageComponent } from './signin-page/signin-page.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { InterceptorService } from './interceptor.service';
import { SavingsGraphComponent } from './savings-graph/savings-graph.component';
@NgModule({
  declarations: [
    AppComponent,
    UserPageComponent,
    SigninPageComponent,
    TopBarComponent,
    SavingsGraphComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: SigninPageComponent },
      { path: 'userpage', component: UserPageComponent },
      { path: 'savingsgraph', component: SavingsGraphComponent}
    ])
  ],
  providers: [
    {
    provide: HTTP_INTERCEPTORS,
    useClass: InterceptorService,
    multi: true
    },
    HttpClientModule
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
