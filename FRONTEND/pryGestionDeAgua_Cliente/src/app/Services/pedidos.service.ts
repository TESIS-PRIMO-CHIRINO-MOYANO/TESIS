import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Pedido } from '../Interfaces/pedido-api';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PedidosService {

 

  constructor(private http: HttpClient) {}

  traerPedidosCliente(idCliente: number): Observable<Pedido[]> {
    var urlApi = environment.endpoint + "pedido/ObtenerPedidosPorCliente/" +  idCliente; 
    return this.http.get<Pedido[]>(urlApi);
  }

  traerPedidosPorId(idPedido:number){
    var urlApi = environment.endpoint + "pedido/ObtenerPedidoPorIdPedido/" +  idPedido; 
    return this.http.get<Pedido>(urlApi);
  }
  
}
