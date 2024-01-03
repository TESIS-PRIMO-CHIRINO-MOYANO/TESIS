import { Component, OnInit } from '@angular/core';
import { Cuenta } from 'src/app/Interfaces/cuenta-corriente';
import { Pedido } from 'src/app/Interfaces/pedido-api';
import { PedidosService } from 'src/app/Services/pedidos.service';
import { DatePipe } from '@angular/common';
@Component({
  selector: 'app-consultar-cuenta',
  templateUrl: './consultar-cuenta.component.html',
  styleUrls: ['./consultar-cuenta.component.css'],

})
export class ConsultarCuentaComponent {
  PedidosUsuario: Pedido[] = [];

  constructor(
    private servicioPedidos: PedidosService
  ) {
    
  }
  idCliente:number= 0; 
  saldo:number = 0;
  pedidosPendientes:number = 0;
  ngOnInit(): void {
    //CARGA DE DATOS PERSONALES
  
    const clienteDataString = localStorage.getItem('cliente');
    const clienteData = JSON.parse(clienteDataString!);
    this.idCliente = clienteData.idCliente; 
    const cuentaDataString = localStorage.getItem('cuenta');
    const cuentaData = JSON.parse(cuentaDataString!);
    this.saldo = cuentaData.monto;
    this.cargarPedidosUsuario();
    
  }
  ngAfterViewInit() {
    const clienteDataString = localStorage.getItem('cliente');
    const clienteData = JSON.parse(clienteDataString!);
    this.idCliente = clienteData.idCliente; 
    const cuentaDataString = localStorage.getItem('cuenta');
    const cuentaData = JSON.parse(cuentaDataString!);
    this.saldo = cuentaData.monto;
    this.cargarPedidosUsuario();
  }
  cargarPedidosUsuario() {
       
    this.servicioPedidos.traerPedidosCliente(this.idCliente).subscribe((results)=>{
      this.PedidosUsuario = results;
      this.pedidosPendientes = this.contarPedidosPendientes(results)
      console.log(results);
    })
      
  }


  contarPedidosPendientes(pedidos: Pedido[]): number {
    return pedidos.filter(pedido => pedido.idEstado == 1).length;
  }

}



