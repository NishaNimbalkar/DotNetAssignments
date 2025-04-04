import { Component } from '@angular/core';
import { Account } from '../../models/account';
import { AccountsService } from '../../services/accounts.service';
import { CommonModule } from '@angular/common';
import { FormsModule, NgForm } from '@angular/forms';
import { Accounttype } from '../../models/accounttype'; // Import the enum
import { RedirectCommand, Route, Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-add-account',
  standalone: true,
  imports: [CommonModule, FormsModule,RouterModule],
  templateUrl: './add-account.component.html',
  styleUrls: ['./add-account.component.css'] 
})
export class AddAccountComponent {
  newAccount: Account = {
    accountNumber: '',
    balance: 0,
    accountType: Accounttype.Saving 
  };

  successMessage = '';
  errorMessage = '';

  constructor(private accountsService: AccountsService,private router:Router) {}

  addAccount(form: NgForm) {
    if (form.invalid) {
      this.errorMessage = 'Please fill in all required fields';
      return;
    }

    this.accountsService.addAccount(this.newAccount).subscribe({
      next: (response) => {
        // this.successMessage = 'Account added successfully!';
        alert( 'Account added successfully!');
        this.router.navigate(['/accounts'])
          this.errorMessage = '';
        form.resetForm(); 
      },
      error: (error) => {
        this.errorMessage = 'Failed to add account.';
        console.error(error);
      }
    });
  }
}
