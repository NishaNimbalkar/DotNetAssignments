import { Component } from '@angular/core';
import { TransactionsService } from '../../services/transactions.service';
import { AccountsService } from '../../services/accounts.service';
import { Router } from '@angular/router';
import { Account } from '../../models/account';

@Component({
  selector: 'app-deleteaccount',
  standalone: true,
  imports: [],
  templateUrl: './deleteaccount.component.html',
  styleUrl: './deleteaccount.component.css'
})
export class DeleteaccountComponent {

    userAccounts: Account[] = [];
  

  constructor(private tran:TransactionsService,private accountsService: AccountsService ,private router:Router) {}


  deleteaccount(aId:number){
    // if(aId==null)return ;
    if(confirm("Do you want to delete this account")){
    this.accountsService.deleteAccount(aId).subscribe(()=>{
      
        this.userAccounts= this.userAccounts.filter(accounts => accounts.id !== aId)

        alert("account deleted successfully")
              
            
    })
    
    
  }
  else{
    alert("unable to delete account")
  }
  }
}
