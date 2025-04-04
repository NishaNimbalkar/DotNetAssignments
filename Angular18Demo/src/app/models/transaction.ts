import { Account } from "./account";
import { Accounttype } from "./accounttype";

export interface Transactions {
    id: number;
    accountId: number;
    account?: Account;
    transactionType:TransactionTypes;
    amount:number;
    date:Date;
    description:string
  
  }
  export enum TransactionTypes {
    credit = 1,
    Debit=2
  }

  
  export class TransactionAddModel {
    accountId: number;  // ✅ Add this property
    amount: number;
    description: string;
    transactionType: TransactionTypes;
    // accountNumber=AccountNumber;
  
    constructor(accountId: number, amount: number, description: string, transactionType: TransactionTypes) {
      this.accountId = accountId;
      this.amount = amount;
      this.description = description;
      this.transactionType = transactionType;
    }
  }
  
