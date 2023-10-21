import { Component, Input, Output, EventEmitter  } from '@angular/core';
import { ProductoInterface } from 'src/app/Interfaces/producto';
import { ProductoCarrito } from 'src/app/Interfaces/producto-carrito';

@Component({
  selector: 'app-card-producto',
  templateUrl: './card-producto.component.html',
  styleUrls: ['./card-producto.component.css'],
 
})
export class CardProductoComponent {
  @Input()  producto!: ProductoInterface;
  valorNumeric:number = 1;
  total:number =  0;
  calcularTotal(precio:number): number{
      return precio * this.valorNumeric;
  }

  carrito: ProductoCarrito[] = [];

  constructor(){
    const carritoEnLocalStorageString = localStorage.getItem('carrito');
    const carritoEnLocalStorage = carritoEnLocalStorageString ? JSON.parse(carritoEnLocalStorageString) : [];
    if (carritoEnLocalStorage) {
      this.carrito = carritoEnLocalStorage;
    }

  }
  agregarAlCarrito(idProducto: number, nombre: string, cantidad: number, precio: number, urlImagen: string) {
    const productoExistente = this.carrito.find(p => p.idProducto === idProducto);
    if (productoExistente) {
      productoExistente.cantidad += cantidad
    } else {
      this.carrito.push({
        idProducto,
        nombre,
        cantidad,
        precio,
        urlImagen
      });
    }

    // Actualizar el carrito en el Local Storage
    localStorage.setItem('carrito', JSON.stringify(this.carrito));
  }
}
