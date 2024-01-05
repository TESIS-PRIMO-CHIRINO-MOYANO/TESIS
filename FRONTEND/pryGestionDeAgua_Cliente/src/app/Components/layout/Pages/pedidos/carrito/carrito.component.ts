import { Component, ElementRef, Input,  } from '@angular/core';
import { ProductoCarrito } from 'src/app/Interfaces/producto-carrito';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { PedidosService } from 'src/app/Services/pedidos.service';
import { Cliente } from 'src/app/Interfaces/cliente';
import { Pedido, ProductosPedidoDTO } from 'src/app/Interfaces/pedido-api';
import { map } from 'rxjs';
@Component({
  selector: 'app-carrito',
  templateUrl: './carrito.component.html',
  styleUrls: ['./carrito.component.css']
})
export class CarritoComponent {
  carrito: ProductoCarrito[] = [];
  total:number = 0 ;
  sguirComprando: boolean = false;
  constructor(
    private formBuilder: FormBuilder,
    private servicioPedidos: PedidosService
  ) {
    
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
  error:boolean=false;



  pedidoForm!: FormGroup;
  
  
  confirmarPedido() {
    //Recuperando datos cliente 
    const jsonFromLocalStorage = localStorage.getItem('cliente');
    const cliente: Cliente = jsonFromLocalStorage ? JSON.parse(jsonFromLocalStorage) : null;
    console.log(cliente);
    //Recuperando fecha
    const fechaFront = (document.getElementById('fechaPedido') as HTMLInputElement).value;
    const fechaConFormato = new Date(fechaFront);
    //Recuperadno datos carrito 

    const jsonString = localStorage.getItem('carrito');
    const pedidos: ProductoCarrito[] = jsonString ? JSON.parse(jsonString) : null;
    const productoPedApi: ProductosPedidoDTO[] = [];
    let i = 0;  
    
 
    while (i < pedidos.length) {

      const item:ProductosPedidoDTO = {
        idPedido: 0,
        idProducto: pedidos[i].idProducto,
        cantidad:  pedidos[i].cantidad,
        esExtra: false,
        total:  pedidos[i].cantidad *  pedidos[i].precio
      } 
      productoPedApi.push(item)	
      i++
    }
   


    const data: Pedido = {
      idPedido: 0,
      fechaPedido: fechaConFormato,
      importeTotal:this.total,
      idCliente:cliente.idCliente,
      idPatente:1,
      idBarrio:cliente.idBarrio,
      idEstado:1,
      productosPedidoDTO:productoPedApi
    }
    
   
    this.servicioPedidos.realizarPedido(data).subscribe(
      response => {
        localStorage.removeItem('carrito');
        this.actualizarLocal();
        this.total = 0;
        this.exito=true;
        this.sguirComprando = true;
        this.error = false;
      },
      error => {
        this.error = true;
      }
    );

   
  }

}
