import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  baseUrl = 'http://localhost:5000/api/user/';
  jwtHelper = new JwtHelperService();
  decodedToken: any;

  constructor(private http: HttpClient) { }

  login(model: any): Observable<void> {
    return this.http
    .post(`${this.baseUrl}login`, model).pipe(
      map((response: any) => {
        const user = response;
        if (user) {
          localStorage.setItem('token', user.token);
          this.decodedToken = this.jwtHelper.decodeToken(user.token);
        }
      })
    );
  }

  register(model: any): Observable<any> {
    return this.http.post(`${this.baseUrl}register`, model);
  }

  loggedIn(): boolean {
    const token = localStorage.getItem('token');
    this.jwtHelper.isTokenExpired(token);
    this.decodedToken = this.jwtHelper.decodeToken(token);
    if (token) {
      return true;
    }
    return false;

  }

}
