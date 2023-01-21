import { Component, OnInit } from '@angular/core';
import { TokenStorageService } from '../_services/tokenStorage/token-storage.service';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})


export class TopBarComponent implements OnInit {
  
  name = 'Angular';
  public isCollapsed = true;
  isLoggedIn: boolean = false;

  constructor(private tokenStorage: TokenStorageService) {}

  ngOnInit(): void {
    if(this.tokenStorage.getToken()) {
      this.isLoggedIn = true;
    }
  }
}
