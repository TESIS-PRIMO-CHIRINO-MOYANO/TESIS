import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { BarrioService } from 'src/app/Services/barrio.service';
import { BarrioInterface } from 'src/app/Interfaces/barrio';

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
      nombre:['',Validators.required],
      apellido:['',Validators.required],
      sexo:['',Validators.required],
      dni:['',Validators.required],
      barrio:['',Validators.required],
      direccion:['',Validators.required],
      piso:['',],
      depto:['',],
      telefono:['',Validators.required],
      email:['',[Validators.required, Validators.email]],
      password:['',[Validators.required, Validators.minLength(8)]]
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
  get email(){
    return this.formularioRegistro.controls.email;
  }
  get pass(){
    return this.formularioRegistro.controls.password;
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
