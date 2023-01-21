import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule, FormGroup, FormControl, FormBuilder } from '@angular/forms';
import * as jwt_decode from 'jwt-decode';

import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { RegisterComponent } from './pages/register/register.component';
import { AboutComponent } from './pages/about/about.component';

import { authInterceptorProviders } from './_helpers/auth.interceptor';
import { LogoutComponent } from './pages/logout/logout.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    TopBarComponent,
    RegisterComponent,
    AboutComponent,
    LogoutComponent
  ],
  imports: [
    BrowserModule, 
    FormsModule, 
    ReactiveFormsModule,
    NgbCollapseModule,
    HttpClientModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: 'login', component: LoginComponent },
      { path: 'login/:refresh', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'about', component: AboutComponent },
      { path: 'logout', component: LogoutComponent }
    ])
  ],
  providers: [authInterceptorProviders],
  bootstrap: [AppComponent]
})
export class AppModule { }
