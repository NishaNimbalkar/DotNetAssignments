import { Login } from './login';

describe('Login', () => {
  it('should create an instance', () => {
    expect(new Login('test@example.com', 'password123')).toBeTruthy();  });
});
