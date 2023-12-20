import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RegistroClienteInterface } from '../Interfaces/registro-cliente';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class RegistroClienteService {
  private urlApi:string = environment.endpoint + "registro/crearUsuario";
  constructor(private http: HttpClient) { }
  registrarUsuario(data: RegistroClienteInterface): Observable<any> {
    return this.http.post(this.urlApi, data);  
  }
}
