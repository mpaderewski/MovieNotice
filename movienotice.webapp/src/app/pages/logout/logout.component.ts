import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from 'src/app/_services/account/account.service';
import { TokenStorageService } from 'src/app/_services/tokenStorage/token-storage.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent {

  constructor(private router: Router, private accountService: AccountService, private tokenStorage: TokenStorageService) {
    if(tokenStorage.getToken()) {
      tokenStorage.signOut();
      router.navigate(['/login', 1]);
    }
  }

}
