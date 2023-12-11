import { Component } from '@angular/core';
import { ProductoCarrito } from 'src/app/Interfaces/producto-carrito';

@Component({
  selector: 'app-detalle-pedido',
  templateUrl: './detalle-pedido.component.html',
  styleUrls: ['./detalle-pedido.component.css']
})
export class DetallePedidoComponent {
  carrito: ProductoCarrito[] = [];
  total:number = 0 ;
  sguirComprando: boolean = false;
  constructor() {
    
    this.actualizarLocal();
  this.calcularTotal();
    this.exito = false;
  }

  actualizarLocal(){
    const carritoEnLocalStorageString = localStorage.getItem('carrito');
    const carritoEnLocalStorage = carritoEnLocalStorageString ? JSON.parse(carritoEnLocalStorageString) : [];
  if (carritoEnLocalStorage) {
    this.carrito = carritoEnLocalStorage;
  }
  }
  calcularTotal(){
    this.total = 0;
    this.carrito.forEach((i)=>{
      this.total += (i.cantidad *i.precio)
    })
  }
  eliminarElementoCarritoPorId(idProducto: number) {
    const index = this.carrito.findIndex((producto) => producto.idProducto === idProducto);

    if (index !== -1) {
      this.carrito.splice(index, 1); // Eliminamos el elemento del array
      this.guardarCarritoEnLocalStorage();
      this.calcularTotal();
    }
  }

  guardarCarritoEnLocalStorage() {
    localStorage.setItem('carrito', JSON.stringify(this.carrito));
    this.actualizarLocal();
    this.calcularTotal();
  }

  exito:boolean=false;
  confirmarPedido() {
    localStorage.removeItem('carrito');
    this.actualizarLocal();
    this.total = 0;
    this.exito=true;
    this.sguirComprando = true;
  }
}
