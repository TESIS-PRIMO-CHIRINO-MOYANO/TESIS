import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './layout.component';
import { DashboardComponent } from './Pages/dashboard/dashboard.component';
import { InicioComponent } from './inicio/inicio.component';
import { ProductosComponent } from './Pages/productos/productos.component';

import { SobreNosotrosComponent } from './sobre-nosotros/sobre-nosotros.component';

const routes: Routes = [
  {
    path:'', 
    component:LayoutComponent,
    children:[
      {path:'', component: InicioComponent},
      {path:'inicio', component: InicioComponent},
      {path:'miCuenta', component: DashboardComponent},
      {path:'productos', component: ProductosComponent},
      {path:'sobreNosotros',component: SobreNosotrosComponent}
    ]
  
  
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class LayoutRoutingModule { }