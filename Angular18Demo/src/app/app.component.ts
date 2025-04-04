import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { HeaderComponent } from './components/header/header.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AccountsComponent} from './components/accounts/accounts.component';
import { AddAccountComponent } from './components/add-account/add-account.component';
import { TransactionsService } from './services/transactions.service';
import { AddtransactionComponent } from './components/addtransaction/addtransaction.component';
import { TransactionHistoryComponent } from './components/transaction-history/transaction-history.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet,LoginComponent,RegisterComponent,HeaderComponent,DashboardComponent,AccountsComponent,AddAccountComponent,AddtransactionComponent,TransactionHistoryComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'Angular18Demo';
}
