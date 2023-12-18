import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { BarrioService } from 'src/app/Services/barrio.service';
import { BarrioInterface } from 'src/app/Interfaces/barrio';
import { RegistroClienteInterface } from 'src/app/Interfaces/registro-cliente';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrls: ['./registro.component.css']
})
export class RegistroComponent {
  formularioRegistro:FormGroup;
  ocultarPass:boolean = true;

  constructor(
    private fb:FormBuilder,
    private router:Router,
    private servicioBarrios:BarrioService
  ) {
    this.formularioRegistro=this.fb.group({
      dni: ['', Validators.required],
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      mail: ['', [Validators.required, Validators.email]],
      password: ['', Validators.required],
      fechaNacimiento: ['', Validators.required],
      idRol: [1, Validators.required],
      calle: [''],
      piso: [''],
      depto: [''],
      telefono: [''],
      idBarrio: [0, Validators.required],
    });


    
  }
  ngOnInit(): void {
    this.traerBarrios()
    
  }
  //Getters para los campos de los fomularios
  get nombre(){
    return this.formularioRegistro.controls.nombre;
  }
  get apellido(){
    return this.formularioRegistro.controls.apellido;
  }
  get sexo(){
    return this.formularioRegistro.controls.sexo;
  }
  get dni(){
    return this.formularioRegistro.controls.dni;
  }
  get barrio(){
    return this.formularioRegistro.controls.barrio;
  }
  get direccion(){
    return this.formularioRegistro.controls.direccion;
  }
  get piso(){
    return this.formularioRegistro.controls.piso;
  }
  get telefono(){
    return this.formularioRegistro.controls.telefono;
  }
  get mail(){
    return this.formularioRegistro.controls.email;
  }
  get pass(){
    return this.formularioRegistro.controls.password;
  }
  get fecha(){
    return this.formularioRegistro.controls.fecha;
  }

  
  registrar(){
    console.log(this.formularioRegistro.value);
    this.router.navigate(['/pages/productos']);
    //Aca Va el codigo una vez que se tenga la api para registrarse.
  }
  barrios?:BarrioInterface[];
  traerBarrios(){
    this.servicioBarrios.traerBarrios().subscribe((result)=>{
      this.barrios = result;
    })
  }



}
