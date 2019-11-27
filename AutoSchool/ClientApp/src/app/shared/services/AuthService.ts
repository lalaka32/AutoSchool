import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import {User} from "../entities/User";

const apiUrl: string = '/api/Auth';
@Injectable()
export class AuthenticationService {

  constructor(private http: HttpClient) { }

  registryUser(user: User) {

    return this.http.post<any>(apiUrl +'/Register', user)
      .pipe(map(user => {
        if (user && user.token) {
          localStorage.setItem('TokenInfo', JSON.stringify(user));
        }

        return user;
      }));
  }

  login(login: string, password: string) {
    return this.http.post<any>(apiUrl +'/Login', { login, password })
      .pipe(map(user => {
        if (user && user.token) {
          localStorage.setItem('TokenInfo', JSON.stringify(user));
        }

        return user;
      }));
  }

  logout() {
    localStorage.removeItem('TokenInfo');
  }
}
