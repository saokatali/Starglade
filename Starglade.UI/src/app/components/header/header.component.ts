import { Component, OnInit } from '@angular/core';
import { LoginService } from '../../services/login.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  isLoggedin: boolean;



  constructor(private loginService: LoginService) { }

  ngOnInit() {
    if (this.loginService.getAuthToken() ) {
        this.isLoggedin = true;
    }

  }

}
