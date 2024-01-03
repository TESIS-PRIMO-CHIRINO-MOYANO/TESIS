import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pedido } from '../Interfaces/pedido-api';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PedidosService {

  private urlApi:string = environment.endpoint + "pedido/ObtenerPedidosPorCliente/";

  constructor(private http: HttpClient) {}

  traerPedidosCliente(idCliente: number): Observable<Pedido[]> {
    this.urlApi += idCliente; 
    return this.http.get<Pedido[]>(this.urlApi);
  }
  
}
