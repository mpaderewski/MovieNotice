import { Injectable } from '@angular/core';
import { TokenStorageService } from '../tokenStorage/token-storage.service';
import jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private decodedToken: any;
  constructor(private tokenStorage: TokenStorageService) {
      this.decodedToken = this.getDecodedAccessToken(tokenStorage.getToken());
   }

  isLogged() : boolean {
    const date = new Date(0);
    try {
    if(this.tokenStorage.getToken()) {
      return true;
    }

    return false;  
  }
  catch(Error) {
    console.log('error');
    return false;
  }
  }

  private getDecodedAccessToken(token: string): any {
    try {
      return jwt_decode(token);
    } catch(Error) {
      return null;
    }
  }

}
