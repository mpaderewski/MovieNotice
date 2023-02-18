import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule } from '@angular/router';
import { NgbCollapseModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule, HttpResponse } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule} from '@angular/forms';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { ToastrModule } from "ngx-toastr";



import { AppComponent } from './app.component';
import { LoginComponent } from './pages/login/login.component';
import { TopBarComponent } from './top-bar/top-bar.component';
import { RegisterComponent } from './pages/register/register.component';
import { AboutComponent } from './pages/about/about.component';

import { authInterceptorProviders } from './_helpers/auth.interceptor';
import { errorCatchingInterceptorProviders } from './_helpers/error-catching.interceptor'
import { LogoutComponent } from './pages/logout/logout.component';
import { SearchMoviesComponent } from './pages/searchMovies/search-movies.component';
import { AuthService } from './_services/auth/auth.service';
import { UserComponent } from './pages/user/user.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    TopBarComponent,
    RegisterComponent,
    AboutComponent,
    LogoutComponent,
    SearchMoviesComponent,
    UserComponent
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
      { path: 'logout', component: LogoutComponent},
      { path: 'searchMovies', component: SearchMoviesComponent},
      { path: 'searchMovies/:title', component: SearchMoviesComponent},
      { path: 'user', component: UserComponent}
]),
    BrowserAnimationsModule,
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: "toast-top-right",
      enableHtml: true
    }),
  ],
  providers: [authInterceptorProviders, errorCatchingInterceptorProviders, AuthService],
  bootstrap: [AppComponent]
})
export class AppModule { }
