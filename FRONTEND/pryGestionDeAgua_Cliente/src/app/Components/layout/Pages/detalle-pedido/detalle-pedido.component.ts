import { Component } from '@angular/core';
import { ProductoCarrito } from 'src/app/Interfaces/producto-carrito';
import { ActivatedRoute } from '@angular/router'
import { PedidosService } from 'src/app/Services/pedidos.service';
import { Pedido } from 'src/app/Interfaces/pedido-api';
import { DetallePedido } from 'src/app/Interfaces/detalle-pedido';
import { ProductoInterface } from 'src/app/Interfaces/producto';
import { ProductoService } from 'src/app/Services/producto.service';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-detalle-pedido',
  templateUrl: './detalle-pedido.component.html',
  styleUrls: ['./detalle-pedido.component.css']
})
export class DetallePedidoComponent {
  idPedido: number = 0;
  pedido!: Pedido;
  productos!: DetallePedido[];
  productoAgregar!: DetallePedido;
  productoPuro!: ProductoInterface;
  totalAmostrar: number = 0;

  constructor(
    private ruta: ActivatedRoute,
    private servicioPedidos: PedidosService,
    private servicioProductos: ProductoService
  ) {
    this.idPedido = Number(this.ruta.snapshot.paramMap.get('idPedido'));
    console.log(this.idPedido);
    this.cargarPedido()
    
  }
  fechaPedido?:Date;
  cargarPedido() {
    this.servicioPedidos.traerPedidosPorId(this.idPedido).subscribe((results) => {
      this.pedido = results;
     
      this.productos = [];
      this.fechaPedido = this.pedido.fechaPedido;
      for (const productoPedido of this.pedido.productosPedidoDTO) {

        //traer producto
        this.servicioProductos.traerProductosPorId(productoPedido.idProducto).subscribe((producto: ProductoInterface) => {
          this.productoPuro = producto;
          
          const productoPvec: DetallePedido = {
            cantidad: productoPedido.cantidad,
            nombre: this.productoPuro.nombre,
            precio: this.productoPuro.precio,
            urlImagen: this.productoPuro.urlImagen
          }
          //calculo del total
          this.totalAmostrar += productoPvec.cantidad * productoPvec.precio;
          //guardar producto en el array para mostrar
          this.productos.push(productoPvec)
        }, (error) => {
          console.error(error);
        });
      }
    })
  }

  
  

}


