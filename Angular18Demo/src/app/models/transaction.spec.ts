import { Transactions } from './transaction'; // Ensure correct import

describe('Transaction', () => {
  it('should create an empty transaction object', () => {
    const transaction: Transactions = {} as Transactions; 

    expect(transaction).toBeTruthy(); 
  });
});
