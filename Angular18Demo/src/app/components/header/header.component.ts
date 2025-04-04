
import { Component, OnInit } from '@angular/core';
import { Router, RouterModule } from '@angular/router';
import { UserService } from '../../services/user.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [RouterModule,CommonModule],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent implements OnInit {

  isLoggedIn:boolean=false;
  email:string|null='';

  
  constructor( public userService:UserService,private router:Router) {}
  ngOnInit(): void {
    // this.userService.isLoggedIn$.subscribe((loggedIn)=>{
    //   this.isLoggedIn=loggedIn;
    //   this.email=localStorage.getItem('email');
    // })

    // ngOnInit(): void {
    //   this.userService.isLoggedIn$.subscribe((loggedIn)=>{
    //     this.isLoggedIn=loggedIn;
    //     this.email=localStorage.getItem('email');
    //   })
     
    // }
    // logout() {
    //   localStorage.clear();
    //   this.router.navigate(['/login']);
    }
  
}
