import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'
import { Observable } from 'rxjs';
import { BarrioInterface } from '../Interfaces/barrio';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class BarrioService {
  private urlApi:string = environment.endpoint + "barrio";

  constructor(private http: HttpClient) {}

  traerBarrios(): Observable<BarrioInterface[]> {
    return this.http.get<BarrioInterface[]>(this.urlApi);
  }
  
}
