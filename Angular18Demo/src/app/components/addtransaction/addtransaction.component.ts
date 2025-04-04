import { Component } from '@angular/core';
// import { Transaction } from '../../models/transaction';
import { CommonModule, NgFor } from '@angular/common';
import { TransactionsService } from '../../services/transactions.service';
import { Router, RouterModule } from '@angular/router';
import { FormsModule, NgForm } from '@angular/forms';
import { TransactionAddModel } from '../../models/transaction';

@Component({
  selector: 'app-addtransaction',
  standalone: true,
  imports: [CommonModule,FormsModule,RouterModule],
  templateUrl: './addtransaction.component.html',
  styleUrl: './addtransaction.component.css'
})
export class AddtransactionComponent {
newTransactionModel:TransactionAddModel=new TransactionAddModel(0,0,'',1);
 

ngonInit() {

}
errorMessage=''
constructor(private transactionService:TransactionsService, private router:Router){}
addTransaction(form:NgForm){
  this.newTransactionModel=form.value
    if(form.invalid){
      this.errorMessage = 'Please fill in all required fields';
     return;
    }
    this.transactionService.addTransaction(this.newTransactionModel).subscribe({
      next: (response) => {
        // this.successMessage = 'Account added successfully!';
        alert( 'Transaction added successfully!');
        this.router.navigate(['/accounts'])
          this.errorMessage = '';
        form.resetForm(); 
        // this.router.navigate(['']);
      },
      error: (error) => {
        this.errorMessage = 'Failed to add Transaction.';
        console.error(error);
      }
    });

    // goToAddTransaction(){
    //   this.router.navigate(['addtransaction'])
    // }

    
}
  
  
}
