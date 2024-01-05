import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout.component';
import { DashboardComponent } from './Pages/dashboard/dashboard.component';
import { InicioComponent } from './Pages/inicio/inicio.component';
import { ProductosComponent } from './Pages/productos/productos.component';
import { SobreNosotrosComponent } from './Pages/sobre-nosotros/sobre-nosotros.component';
import { LoginComponent } from './Pages/login/login.component';
import { RegistroComponent } from './Pages/registro/registro.component';

import { CarritoComponent } from './Pages/pedidos/carrito/carrito.component';
import { ConsultarCuentaComponent } from './Pages/pedidos/consultar-cuenta/consultar-cuenta.component';
import { DetallePedidoComponent } from './Pages/detalle-pedido/detalle-pedido.component';



const routes: Routes = [
  {
    path:'', 
    component:LayoutComponent,
    children:[
      {path:'', component: InicioComponent},
      {path:'inicio', component: InicioComponent},
      {path:'miCuenta', component: DashboardComponent},
      {path:'productos', component: ProductosComponent},
      {path:'sobreNosotros',component: SobreNosotrosComponent},
      {path:'carrito',component:CarritoComponent},
      {path:'consultarCuenta',component:ConsultarCuentaComponent},
      {path:'detallePedido/:idPedido',component:DetallePedidoComponent},
      
      {path:'login', component: LoginComponent},
      {path:'registro', component:RegistroComponent}

    ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }