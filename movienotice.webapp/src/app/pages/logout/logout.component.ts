import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account/account.service';
import { TokenStorageService } from 'src/app/_services/tokenStorage/token-storage.service';

@Component({
  selector: 'app-logout',
  templateUrl: './logout.component.html',
  styleUrls: ['./logout.component.css']
})
export class LogoutComponent {

  constructor(private router: Router, private accountService: AccountService, private tokenStorage: TokenStorageService,private toasters: ToastrService) {
    if(tokenStorage.getToken()) {
      tokenStorage.signOut();
      this.toasters.success('Poprawnie wylogowano!');
      setTimeout(() => {
        router.navigate(['/login', true]);
    }, 1000);
    }
  }

}
