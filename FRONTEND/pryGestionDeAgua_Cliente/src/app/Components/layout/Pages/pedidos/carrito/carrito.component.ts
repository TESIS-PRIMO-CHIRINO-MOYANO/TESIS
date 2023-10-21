import { Component, Input  } from '@angular/core';
import { ProductoCarrito } from 'src/app/Interfaces/producto-carrito';

@Component({
  selector: 'app-carrito',
  templateUrl: './carrito.component.html',
  styleUrls: ['./carrito.component.css']
})
export class CarritoComponent {
  carrito: ProductoCarrito[] = [];
  total:number = 0 ;
  constructor() {
    const carritoEnLocalStorageString = localStorage.getItem('carrito');
    const carritoEnLocalStorage = carritoEnLocalStorageString ? JSON.parse(carritoEnLocalStorageString) : [];
  if (carritoEnLocalStorage) {
    this.carrito = carritoEnLocalStorage;
  }
  this.calcularTotal();
  console.log(this.carrito);
  }
  calcularTotal(){
    this.carrito.forEach((i)=>{
      this.total += (i.cantidad *i.precio)
    })
  }
}
