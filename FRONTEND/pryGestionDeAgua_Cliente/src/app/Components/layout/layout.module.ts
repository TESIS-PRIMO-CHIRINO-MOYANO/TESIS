import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient } from '@angular/common/http';

import { LayoutRoutingModule } from './layout-routing.module';
import { DashboardComponent } from './Pages/dashboard/dashboard.component';
import { InicioComponent } from './inicio/inicio.component';
import { SobreNosotrosComponent } from './sobre-nosotros/sobre-nosotros.component';
import { ProductosComponent } from './Pages/productos/productos.component';
import { CardProductoComponent } from './card-producto/card-producto.component';


@NgModule({
  declarations: [
    DashboardComponent,
    InicioComponent,
    SobreNosotrosComponent,
    ProductosComponent,
    CardProductoComponent, 
    
  ],
  imports: [
    CommonModule,
    LayoutRoutingModule,

  ]
})
export class LayoutModule { }
