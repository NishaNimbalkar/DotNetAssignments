import { Register } from './register';

describe('Register', () => {
  it('should allow creating a Register object with required properties', () => {
    const testRegister: Register = {} as Register; 
    expect(testRegister).toBeTruthy();
  });
});
