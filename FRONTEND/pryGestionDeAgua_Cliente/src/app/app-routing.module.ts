import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './Components/login/login.component';

const routes: Routes = [
  {path:'login' ,component: LoginComponent},
  {path:'', loadChildren:()=> import("./Components/layout/layout.module").then(m => m.LayoutModule)},
  {path:'**', redirectTo:'menu',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
