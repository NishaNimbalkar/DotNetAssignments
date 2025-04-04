import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustominterceptorService implements HttpInterceptor {

  
  constructor() { }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token=localStorage.getItem('token')   // getting token from local storage
    if(token){
      const clonedRequest=req.clone({
        setHeaders:{
          Authorization:`Bearer ${token}` 
        }     
        });
        return next.handle(clonedRequest);
      }
      return next.handle(req);
    }
  }


