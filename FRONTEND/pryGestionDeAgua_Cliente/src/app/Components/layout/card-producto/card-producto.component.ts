import { Component, Input, Output, EventEmitter  } from '@angular/core';
import { ProductoInterface } from 'src/app/Interfaces/producto';

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

  @Output() agregarProductoAlCarrito = new EventEmitter();

  agregarAlCarrito(producto: any) {
    this.agregarProductoAlCarrito.emit(producto);

  }
}
