import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Account } from '../models/account';

@Injectable({
  providedIn: 'root'
})
export class AccountsService {

  private apiUrl = 'https://localhost:7108/api/Account'; // Define API URL

  constructor(private http: HttpClient) {}

  getAllAccounts(): Observable<Account[]> {
    return this.http.get<Account[]>(this.apiUrl); // Corrected return statement
  }
  getAccountByUserId(): Observable<Account[]> {
    return this.http.get<Account[]>(`${this.apiUrl}/ByUserId`);

  }
  getAccountById(){
    return this.http.delete<Account>(`{this.apiUrl}/?`)
  }
  addAccount(account: Account): Observable<Account> {
    return this.http.post<Account>(this.apiUrl, account);
  }
  
  deleteAccount(id:number):Observable<any>{
    return this.http.delete<Account>(`${this.apiUrl}/${id}`);
    

  }
}
