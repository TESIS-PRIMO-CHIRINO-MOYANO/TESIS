import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

import { LayoutRoutingModule } from './layout-routing.module';
import { DashboardComponent } from './Pages/dashboard/dashboard.component';
import { InicioComponent } from './Pages/inicio/inicio.component';
import { SobreNosotrosComponent } from './Pages/sobre-nosotros/sobre-nosotros.component';
import { ProductosComponent } from './Pages/productos/productos.component';
import { CardProductoComponent } from './card-producto/card-producto.component';

import { LoginComponent } from './Pages/login/login.component';
import { RegistroComponent } from './Pages/registro/registro.component';


@NgModule({
  declarations: [
    DashboardComponent,
    InicioComponent,
    SobreNosotrosComponent,
    ProductosComponent,
    CardProductoComponent, 
    LoginComponent, RegistroComponent
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,

  ]
})
export class LayoutModule { }
