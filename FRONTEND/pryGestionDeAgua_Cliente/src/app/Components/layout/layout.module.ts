import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

import { LayoutRoutingModule } from './layout-routing.module';
import { DashboardComponent } from './Pages/dashboard/dashboard.component';
import { InicioComponent } from './Pages/inicio/inicio.component';
import { SobreNosotrosComponent } from './Pages/sobre-nosotros/sobre-nosotros.component';
import { ProductosComponent } from './Pages/productos/productos.component';
import { CardProductoComponent } from './card-producto/card-producto.component';
import { CarritoComponent } from './Pages/pedidos/carrito/carrito.component';
import { ConsultarCuentaComponent } from './Pages/pedidos/consultar-cuenta/consultar-cuenta.component';
import { ConsultarPedidosComponent } from './Pages/pedidos/consultar-pedidos/consultar-pedidos.component';
import { NuevoPedidoComponent } from './Pages/pedidos/nuevo-pedido/nuevo-pedido.component';


@NgModule({
  declarations: [
    DashboardComponent,
    InicioComponent,
    SobreNosotrosComponent,
    ProductosComponent,
    CardProductoComponent,
    CarritoComponent,
    ConsultarCuentaComponent,
    ConsultarPedidosComponent,
    NuevoPedidoComponent, 
    
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,

  ]
})
export class LayoutModule { }
