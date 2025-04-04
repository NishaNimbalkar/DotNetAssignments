import { Component, OnInit } from '@angular/core';
import { RouterService } from '../../services/router.service';
import { UserService } from '../../services/user.service';

@Component({
  selector: 'app-logout',
  standalone: true,
  imports: [],
  templateUrl: './logout.component.html',
  styleUrl: './logout.component.css'
})
export class LogoutComponent implements OnInit {

constructor(private routerService:RouterService,private userService:UserService){}
ngOnInit():void{
localStorage.clear();
this.userService.updateLoginStatus(false);
this.routerService.goToLogin();
}
}