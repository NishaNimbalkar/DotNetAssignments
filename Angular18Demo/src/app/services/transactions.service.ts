import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { TransactionAddModel, Transactions } from '../models/transaction';

@Injectable({
  providedIn: 'root'
})
export class TransactionsService {
aId!:number;
  private apiUrl="https://localhost:7108/api/Transaction";


  constructor(private http: HttpClient) {}
  getId(id: number) {
    this.aId = id;
  }

  getTransactions():Observable<Transactions[]>{
    return this.http.get<Transactions[]>(`https://localhost:7108/api/Transaction/account/${this.aId}`);
  }
  addTransaction(transactionData:TransactionAddModel):Observable<TransactionAddModel>{
    transactionData. accountId = this.aId;
    return this.http.post<TransactionAddModel>(`https://localhost:7108/api/Transaction?id=${this.aId}`,transactionData);
}
  
  
}
