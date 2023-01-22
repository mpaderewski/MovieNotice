import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from '../_services/auth/auth.service';
import { TokenStorageService } from '../_services/tokenStorage/token-storage.service';

@Component({
  selector: 'app-top-bar',
  templateUrl: './top-bar.component.html',
  styleUrls: ['./top-bar.component.css']
})


export class TopBarComponent implements OnInit {
  
  name = 'Angular';
  public isCollapsed = true;
  isLoggedIn: any;
  public movieTitle: string = '';

  searchForm: FormGroup = this.builder.group({
    movieTitle: this.movieTitle
  });

  constructor(private tokenStorage: TokenStorageService, private auth: AuthService, private builder: FormBuilder, private router: Router) {}

  ngOnInit(): void {
    this.isLoggedIn = this.auth.isLogged();
    console.log(this.isLoggedIn);
  }

  searchMovie() {
    if(this.searchForm.value.movieTitle) {
      console.log(this.searchForm.value.movieTitle);
      this.router.navigate(["searchMovies", this.searchForm.value.movieTitle]);
    }
  }
}
