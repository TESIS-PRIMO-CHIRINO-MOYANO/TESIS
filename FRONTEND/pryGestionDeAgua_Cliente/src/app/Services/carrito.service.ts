import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class CarritoService {
  productosSeleccionados: any[] = [];

  agregarAlCarrito(producto: any) {
    this.productosSeleccionados.push(producto);
  }

  eliminarDelCarrito(index: number) {
    this.productosSeleccionados.splice(index, 1);
  }
}
