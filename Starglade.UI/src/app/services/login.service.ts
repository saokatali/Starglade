import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  public token: any;

  constructor() { }

  getAuthToken() {
    return localStorage.authToken;
  }


}
