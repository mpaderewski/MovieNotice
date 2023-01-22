import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { AccountService } from 'src/app/_services/account/account.service';
import { UserRegister } from 'src/app/Models/UserRegister';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit{
  
  //public movies: Movie[] = [];

  registerForm!: FormGroup;
  
  registerData = {password: '', repeatPassword: '', email: '' };

  get email() { return this.registerForm.get('email'); }

  get password() { return this.registerForm.get('password'); }

  get repeatPassword() { return this.registerForm.get('repeatPassword'); }

  constructor(private builder: FormBuilder, private accountService: AccountService, private toasters: ToastrService) {}

  ngOnInit(): void {
    this.registerForm = this.builder.group({
      email: new FormControl (this.registerData.email, [
        Validators.required,
        Validators.email
      ]),
      password: new FormControl(this.registerData.password, [
        Validators.required,
        Validators.minLength(6)
      ]),
      repeatPassword: new FormControl(this.registerData.repeatPassword, [
        Validators.required,
        Validators.minLength(6)
      ]),
    });
  }



  register() {
    this.accountService.registerUser(new UserRegister(this.email?.value, this.password?.value, this.repeatPassword?.value, this.email?.value))
    .subscribe((response) => {
      this.toasters.success('Za chwilę nastąpi przekierowanie do strony logowania.', 'Poprawnie zarejestrowano!');
      setTimeout(() => {
        setTimeout(() => {
          window.location.href="/login";
        });
      }, 3000);        
    });
  }

}
