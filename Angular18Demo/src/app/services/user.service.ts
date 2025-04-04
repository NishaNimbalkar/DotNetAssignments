import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AuthResponseModel, Login } from '../models/login';
import { RegistrationResponse ,Register} from '../models/register';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  updateLoginStatus(arg0: boolean) {
    throw new Error('Method not implemented.');
  }
  private apiUrl = 'https://localhost:7108/api/Auth';

  constructor(private http: HttpClient) { }

  login(loginData: Login): Observable<AuthResponseModel> {
    return this.http.post<AuthResponseModel>(`${this.apiUrl}/login`, loginData);
  }
    register(user:Register):Observable<RegistrationResponse>{
      return this.http.post<RegistrationResponse>(`${this.apiUrl}/register`, user);
    }
    
      isLoggedIn$():boolean{
        return !!localStorage.getItem('token');
      }
      //To Notify subscribes
      // updateLoginStatus(isLoggedIn:boolean){
      //   this.loggedIn.next(isLoggedIn);
    // }
}
