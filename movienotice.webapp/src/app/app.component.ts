import { Component } from '@angular/core';
import { TokenStorageService } from './_services/tokenStorage/token-storage.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'movienotice.webapp';
  token: string = '';
  constructor(private tokenStorage: TokenStorageService) {
    this.token = tokenStorage.getToken();

  }
}
