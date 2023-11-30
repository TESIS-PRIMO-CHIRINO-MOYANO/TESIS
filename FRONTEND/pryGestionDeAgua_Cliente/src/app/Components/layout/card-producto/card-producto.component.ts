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
    const carritoActualString = localStorage.getItem('carrito');
    const carritoActual = carritoActualString ? JSON.parse(carritoActualString) : [];

    const productoExistenteIndex = carritoActual.findIndex((p: { idProducto: number; }) => p.idProducto === idProducto);

    if (productoExistenteIndex !== -1) {
        // Si el producto ya existe, aumentar la cantidad
        carritoActual[productoExistenteIndex].cantidad += cantidad;
    } else {
        // Si el producto no existe, agregarlo al carrito
        carritoActual.push({
            idProducto,
            nombre,
            cantidad,
            precio,
            urlImagen
        });
    }

    // Almacenar el carrito actualizado en el Local Storage
    localStorage.setItem('carrito', JSON.stringify(carritoActual));
    this.mostrarMensajeAgregado()
  }
  mensajeAgregado:boolean = false;
  mostrarMensajeAgregado() {
    this.mensajeAgregado = true;
    setTimeout(() => {
      this.mensajeAgregado = false;
    }, 1000); // 3000 milisegundos (3 segundos)
  }
}
