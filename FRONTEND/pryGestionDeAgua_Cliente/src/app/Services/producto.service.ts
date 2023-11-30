import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { ProductoInterface } from '../Interfaces/producto';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  private urlApi:string = environment.endpoint + "producto";

  constructor(private http: HttpClient) {}

  traerProductos(): Observable<ProductoInterface[]> {
    return this.http.get<ProductoInterface[]>(this.urlApi);
  }
  
}



