import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RouterService {

  constructor(private router:Router) { }
  gotoDahboard(){
    this.router.navigate(['dashBoard'])
  }
  goToLogin(){
    this.router.navigate(['login'])
  }
  goToAddAccount(){
    this.router.navigate(['add-account'])
  }
  gotoAddTransaction(){
    this.router.navigate(['addtransaction'])

  }
  gotoAllTransactions(){
    this.router.navigate(['transaction-history'])
  }
  deleteAccount(){
    this.router.navigate(['accounts']);

  }
}
