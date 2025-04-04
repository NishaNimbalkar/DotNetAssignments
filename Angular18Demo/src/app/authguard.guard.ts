import { CanActivateFn } from '@angular/router';
import { UserService } from './services/user.service';
import { inject } from '@angular/core';

export const authguardGuard: CanActivateFn = (route, state) => {
  return true;
  // const userService=inject(UserService);
  // if(userService.isLoggedIn()){
  //   return true;
  // }
  // else{
  //   return false;
  // }

};
