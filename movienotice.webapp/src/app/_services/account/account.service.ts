import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserLogin } from 'src/app/Models/UserLogin';
import { AppSettings } from 'src/app/appSettings';

const CONTROLLER = 'account/';

@Injectable({
  providedIn: 'root'
})

export class AccountService {

  constructor(private http: HttpClient) { }

  signInUser(user: UserLogin){
    return this.http.post(AppSettings._API_URL + CONTROLLER + 'login', user, {responseType: 'text'});
  }

}
