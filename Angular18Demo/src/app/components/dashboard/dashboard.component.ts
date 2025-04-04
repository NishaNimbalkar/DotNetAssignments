import { Component, OnInit } from '@angular/core';
import { Account } from '../../models/account';
import { CommonModule } from '@angular/common';
import { AccountsService } from '../../services/accounts.service'; // Import service

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css'] 
})
export class DashboardComponent implements OnInit {
  accounts: Account[] = [];
  // displayEmail?=string |null;

  constructor(private accountService: AccountsService) {} 

  ngOnInit() {
    // this.displayEmail=localStorage.getItem('email')
    this.getAllAccounts();
  }

  getAllAccounts() {
    this.accountService.getAllAccounts().subscribe(data => {
      console.log(data);
      this.accounts = data; 
    });
  }
}
