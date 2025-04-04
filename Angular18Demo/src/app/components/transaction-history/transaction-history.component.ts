import { Component, OnInit } from '@angular/core';
import { TransactionsService } from '../../services/transactions.service';
import { TransactionAddModel, Transactions } from '../../models/transaction';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { Router, RouterModule } from '@angular/router';
import { TransactionType } from '../../models/accounttype';

@Component({
  selector: 'app-transaction-history',
  standalone: true,
  imports: [CommonModule, FormsModule, RouterModule],
  templateUrl: './transaction-history.component.html',
  styleUrls: ['./transaction-history.component.css']
})
export class TransactionHistoryComponent implements OnInit {
  transactions: Transactions[] = [];  

  tranType = TransactionType;  

  constructor(private transactionService: TransactionsService, private router: Router) {}

  ngOnInit() {
    this.getTransactionHistory();  
  }

  errorMessage = '';

  

  getTransactionHistory() {
    this.transactionService.getTransactions().subscribe({
      next: (transactions) => {
        console.log('Fetched Transactions:', transactions);
        this.transactions = transactions;  
      },
      error: (error) => {
        console.error('Error fetching transactions:', error);
      }
    });
  }
}
