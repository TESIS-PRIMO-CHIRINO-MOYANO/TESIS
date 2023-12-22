import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { LoginResponse } from '../Interfaces/login-respuesta';
import { CredencialesLogin } from '../Interfaces/credenciales-login';
import { environment } from 'src/environments/environment';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class SharedService {
  private isLoggedInSource = new BehaviorSubject<boolean>(false);
  isLoggedIn$ = this.isLoggedInSource.asObservable();

  setLoggedIn(value: boolean): void {
    this.isLoggedInSource.next(value);
  }
}
@Injectable({
  providedIn: 'root'
})
export class AuthService {

  private urlApi:string = environment.endpoint + 'login/loginCliente'; 

  constructor(private http: HttpClient) {}

  login(credenciales:CredencialesLogin): Observable<LoginResponse> {
    const parameters = credenciales;
    return this.http.post<LoginResponse>(this.urlApi , parameters);
  }
}
