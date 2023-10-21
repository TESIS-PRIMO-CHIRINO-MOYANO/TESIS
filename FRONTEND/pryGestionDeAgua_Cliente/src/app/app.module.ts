import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';

import { LayoutComponent } from './Components/layout/layout.component';
import { HttpClientModule } from '@angular/common/http';

import { CarritoService } from './Services/carrito.service';

import { SharedModule } from './Reutilizable/shared/shared.module';

@NgModule({
  declarations: [
    AppComponent,
    LayoutComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    SharedModule
  ],
  providers: [CarritoService],
  bootstrap: [AppComponent],
})
export class AppModule { }
