import { Accounttype } from "./accounttype";

export interface Account {
    id?:number ;
    userId?:string;
    accountNumber?:string;
    balance?:number;
    accountType:Accounttype;
    createdDate?:Date


}
export interface AccountResponse {
    userId:string
}










