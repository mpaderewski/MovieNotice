import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './_services/auth/auth.service';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'movienotice.webapp';

  constructor(private auth: AuthService, private router: Router) {
    if(!auth.isLogged()) {
      router.navigate(['/login']);
    }
  } 
}
