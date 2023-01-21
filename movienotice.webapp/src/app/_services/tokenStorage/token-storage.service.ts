import { Injectable } from '@angular/core';
import { UserLogin } from 'src/app/Models/UserLogin';
 
const TOKEN_KEY = 'auth-token';
const USER_KEY = 'auth-user';
 
@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {
 
  constructor() { }
 
  signOut(): void {
    localStorage.clear();
  }
 
  public saveToken(token: string): void {
    localStorage.removeItem(TOKEN_KEY);
    localStorage.setItem(TOKEN_KEY, token);
  }
 
  public getToken(): string{
    return localStorage.getItem(TOKEN_KEY) as string;
  }
 
  public saveUser(user: UserLogin): void {
    localStorage.removeItem(USER_KEY);
    localStorage.setItem(USER_KEY, JSON.stringify(user));
  }
 
  public getUser(): any {
    return JSON.parse(localStorage.getItem(USER_KEY) as string);
  }
}