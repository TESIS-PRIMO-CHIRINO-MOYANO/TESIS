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
import { DetallePedidoComponent } from './Pages/detalle-pedido/detalle-pedido.component';


import { LoginComponent } from './Pages/login/login.component';
import { RegistroComponent } from './Pages/registro/registro.component';
import { SharedModule } from 'src/app/Reutilizable/shared/shared.module';
import { PaginaErrorComponent } from './Pages/pagina-error/pagina-error.component';
import { MiCuentaComponent } from './Pages/mi-cuenta/mi-cuenta.component';



@NgModule({
  declarations: [
    DashboardComponent,
    InicioComponent,
    SobreNosotrosComponent,
    ProductosComponent,
    CardProductoComponent,
    CarritoComponent,
    ConsultarCuentaComponent,
    DetallePedidoComponent,
    RegistroComponent,
    LoginComponent,
    PaginaErrorComponent,
    MiCuentaComponent
   
    
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,
    SharedModule

  ]
})
export class LayoutModule { }
