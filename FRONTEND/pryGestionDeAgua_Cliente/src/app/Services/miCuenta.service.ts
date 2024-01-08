import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { miCuentaInterface } from '../Interfaces/miCuenta';
import { environment } from 'src/environments/environment';

  
@Injectable({
    providedIn: 'root'
  })

  export class micuentaService {
    private urlApi:string = environment.endpoint + "registro/crearUsuario";
    constructor(private http: HttpClient) { }
    registrarUsuario(data: miCuentaInterface): Observable<any> {
      return this.http.post(this.urlApi, data);  
    }
  } 