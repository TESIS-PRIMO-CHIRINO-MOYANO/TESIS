import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { ProductoInterface } from '../Interfaces/producto';
@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  private dataUrl = '/assets/productos.json'; // Ruta al archivo JSON

  constructor(private http: HttpClient) {}

  traerProductos(): Observable<ProductoInterface[]> {
    return this.http.get<ProductoInterface[]>(this.dataUrl);
  }
  
}



