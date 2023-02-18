import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/Models/User';
import { UserService } from 'src/app/_services/user/user.service';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit{

  public user: User | undefined;

  constructor(private userService: UserService, private toasters: ToastrService) {

  }

  ngOnInit(){
    this.userService.getUser().subscribe((response) =>
    {
      this.user = response;
    });
  }
}
