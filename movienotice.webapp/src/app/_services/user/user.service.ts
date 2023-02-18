import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppSettings } from 'src/app/appSettings';
import { User } from 'src/app/Models/User';

const CONTROLLER = 'User/';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getUser(){
    return this.http.get<User>(AppSettings._API_URL + CONTROLLER + 'Get');
  }

}
