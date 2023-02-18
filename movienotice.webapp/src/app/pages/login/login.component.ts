import { Component, OnInit,  } from '@angular/core';
import { AccountService } from 'src/app/_services/account/account.service';
import { UserLogin } from 'src/app/Models/UserLogin';
import { FormGroup, FormControl, FormBuilder } from '@angular/forms';
import { TokenStorageService } from 'src/app/_services/tokenStorage/token-storage.service';
import { catchError } from 'rxjs/internal/operators/catchError';
import { EMPTY } from 'rxjs';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from 'src/app/_services/auth/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit{
  email = new FormControl('')
  password = new FormControl('')
  token: string = '';

  form: any = {};
  isLoggedIn = false;
  isLoginFailed = false;
  errorMessage = '';
  roles: string[] = [];

  loginForm: FormGroup = this.builder.group({
    email: this.email,
    password: this.password
  });

  constructor(private accountService: AccountService, private builder: FormBuilder, private tokenStorage: TokenStorageService,
    private route: ActivatedRoute, private auth: AuthService, private toasters: ToastrService) { }
  ngOnInit(): void {
    this.isLoggedIn = this.auth.isLogged();
    if (this.isLoggedIn) {
      console.log(this.isLoggedIn);
      //window.location.href="/"
    }
    else {
      this.route.params
      .subscribe(params => {
        console.log(params['refresh']);

        if(params['refresh']) {
          console.log('if');
          window.location.href="/login"
        }
      });
    }
  }

  login() {
    console.log(this.loginForm.value);
    this.accountService.signInUser(new UserLogin(this.loginForm.value.email, this.loginForm.value.password)).pipe(
      catchError(() => {
        return EMPTY;
       })
    ).subscribe((response) => {

      this.token = response;
      this.tokenStorage.saveToken(response);
      this.tokenStorage.saveUser(new UserLogin(this.loginForm.value.email, this.loginForm.value.password));
      this.isLoginFailed = false;
      this.isLoggedIn = true;
      this.toasters.success('Za chwilę nastąpi przekierowanie do strony głównej.', 'Poprawnie zalogowano!');
      setTimeout(() => {
        setTimeout(() => {
          window.location.href="/";
        });
      }, 3000);
    });
  }
}
