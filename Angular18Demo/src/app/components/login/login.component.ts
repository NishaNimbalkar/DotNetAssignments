import { Component } from '@angular/core';
import { AuthResponseModel, Login } from '../../models/login';
import { UserService } from '../../services/user.service';
import { FormsModule, NgForm } from '@angular/forms';

import { CommonModule } from '@angular/common';

import {Router }from '@angular/router';
import { RouterService } from '../../services/router.service';
@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule,FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
loginModel:Login=new Login('','');
errorMsg='';
constructor(private router:Router, private userService:UserService,private routerService:RouterService){}

ngonInit(){
  //this.loginUser();
}
//#region HardcodedValues
  // loginUser() {
  //   this.loginModel.email="vani@gmail.com";
  //   this.loginModel.password="Vani@123";
  //   this.userService.login(this.loginModel).subscribe(res=>{
  //     console.log(res);
      
  //   })
  // }
  //#endregion
loginUser(loginForm:NgForm){
this.loginModel=loginForm.value;
console.log(this.loginModel);
this.userService.login(this.loginModel).subscribe({
  next:(response:AuthResponseModel)=>{
    console.log('Login Succes',response);
    localStorage.setItem('token',response.token)
    localStorage.setItem('userId', response.id)
    // localStorage.setItem('email',response.email);
    // this.userService.updateLoginStatus(true);
    alert('LoginSuccess');
    localStorage.getItem('userId')
    loginForm.reset();
  //  this.router.navigate(['/dashBoard'])
  this.router.navigate(['/accounts'])
  //  this.routerService.gotoDashBoard();
    
  },
  error:(error)=>{
    console.error('LoginFailed',error)
    this.errorMsg="Invalid Email or Password"
    this.errorMsg=JSON.stringify(error.error)
    alert(this.errorMsg)
    

    
  }
  
})

}
}