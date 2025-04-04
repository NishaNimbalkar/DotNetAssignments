import { Component, OnInit } from '@angular/core';
import { AccountsService } from '../../services/accounts.service';
import { Account } from '../../models/account';
import { CommonModule } from '@angular/common';
import { Route, Router, RouterModule } from '@angular/router';
import { TransactionsService } from '../../services/transactions.service';
import { Accounttype } from '../../models/accounttype';

@Component({
  selector: 'app-accounts',
  standalone: true,
    imports: [CommonModule,RouterModule],
  
  templateUrl: './accounts.component.html',
  styleUrls: ['./accounts.component.css']
})
export class AccountsComponent implements OnInit {
  userAccounts: Account[] = [];
  userId: string | null = '';
  allTypes = Accounttype ;
  // id:null| undefined;

  constructor(private tran:TransactionsService,private accountsService: AccountsService ,private router:Router) {}

  ngOnInit() {
    this.userId = localStorage.getItem('userId'); // Get userId from localStorage

    if (this.userId) {
      this.getUserAccounts(this.userId);
    }
    else{
      console.log("User Id Not Found in Local Storage")
    }
  }

  deleteaccount(aId:number){
    // if(aId==null)return ;
    if(confirm("Do you want to delete this account")){
    this.accountsService.deleteAccount(aId).subscribe(()=>{
      alert("account deleted successfully")

        this.userAccounts= this.userAccounts.filter(accounts => accounts.id !== aId)

              
            
    
  
    });  

    
  }
  }

 

  getUserAccounts(userId:string) {
    this.accountsService.getAccountByUserId().subscribe({
      next: (accounts) => {
        this.userAccounts = accounts;
      },

      error: (error) => {
        console.error('Error fetching accounts:', error);
      }
    });
  }
    goToAddAccount(){
      this.router.navigate(['/add-account']);
    }
    
    // deleteAccount(id?:number){
    //   // if(id== null || id== undefined) return;
    //   // this.tran.getId(id);
    //   this.router.navigate(['/accounts']);

    // }
    gotoAddTransaction(id?:number){
      if(id== null || id== undefined) return;
      this.tran.getId(id);
      this.router.navigate(['addtransaction']);
    }
    gotoAllTransactions(id?:number){
      if(id== null || id== undefined) return;

      this.tran.getId(id);
      // console.log(id);
      this.router.navigate(['transaction-history']);
  
    }
  }

