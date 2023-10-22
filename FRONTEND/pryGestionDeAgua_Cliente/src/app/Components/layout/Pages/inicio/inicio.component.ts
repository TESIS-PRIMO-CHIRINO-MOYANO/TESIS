import { Component,OnInit } from '@angular/core';
import { ProductoInterface } from 'src/app/Interfaces/producto';
import { ProductoService } from 'src/app/Services/producto.service';

@Component({
  selector: 'app-inicio',
  templateUrl: './inicio.component.html',
  styleUrls: ['./inicio.component.css']
})
export class InicioComponent implements OnInit{
  productos?: ProductoInterface[]; 
  constructor(
    private servicioProductos: ProductoService
  ){}
  ngOnInit(): void {
    this.servicioProductos.traerProductos().subscribe((result)=>{
      this.productos = result
    })
  }
}
