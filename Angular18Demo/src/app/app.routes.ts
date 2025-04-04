import { Routes } from '@angular/router';
import { RegisterComponent } from './components/register/register.component';
import { LoginComponent } from './components/login/login.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { AccountsComponent } from './components/accounts/accounts.component';
import { AddAccountComponent } from './components/add-account/add-account.component';
import { AddtransactionComponent } from './components/addtransaction/addtransaction.component';
import { TransactionHistoryComponent } from './components/transaction-history/transaction-history.component';
import { LogoutComponent } from './components/logout/logout.component';
import { HomeComponent } from './components/home/home.component';
import { DeleteaccountComponent } from './components/deleteaccount/deleteaccount.component';

export const routes: Routes = [
    {
        path:'register',component:RegisterComponent,

    },
    { path: '', component: HomeComponent },
    {path:'login',component:LoginComponent},
    {path:'dashBoard',component:DashboardComponent},
    {path:'register',component:RegisterComponent},
    {path:'accounts',component:AccountsComponent},
    { path: 'add-account', component: AddAccountComponent },
    {path:'addtransaction',component:AddtransactionComponent},
    {path:'transaction-history',component:TransactionHistoryComponent},
    {path:'logout',component:LogoutComponent },
    {path:'deleteaccount',component:DeleteaccountComponent}

];
