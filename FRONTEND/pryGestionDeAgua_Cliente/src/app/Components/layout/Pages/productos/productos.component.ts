import { Component, OnInit} from '@angular/core';
import { ProductoInterface } from 'src/app/Interfaces/producto';
import { ProductoService } from 'src/app/Services/producto.service';
@Component({
  selector: 'app-productos',
  templateUrl: './productos.component.html',
  styleUrls: ['./productos.component.css']
})


export class ProductosComponent implements OnInit{
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
