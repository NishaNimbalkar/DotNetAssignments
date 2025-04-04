import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { UserService } from '../../services/user.service';
import { Register } from '../../models/register';
// import { error } from 'console';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { RouterService } from '../../services/router.service';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [ReactiveFormsModule,CommonModule,FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent implements OnInit {
  registerForm!:FormGroup;
 errorMsg='';
   constructor(private  fb:FormBuilder, private userService: UserService,private routerService:RouterService){

   }
  ngOnInit():void{
    this.registerForm=this.fb.group({
      firstName:['',Validators.required],
      lastName: ['',Validators.required],
      location:['',Validators.required],
      email:['',[Validators.required,Validators.email]],
      userName:['',Validators.required],
      password:['',[Validators.required]]


    });

  }
  
  registerUser(user:FormGroup){
    
    this.userService.register(user.value).subscribe({
      next:(response)=>{
        console.log(response);
        alert('Registration Success');
        this.registerForm?.reset();
      //  this.router.navigate(['login'])
       this.routerService.goToLogin();
        
      },
      error:(err)=>{
        console.error('register Failed:',err)
        this.errorMsg=JSON.stringify(err.error)
        alert(this.errorMsg);
      }
      
    })
  }
}