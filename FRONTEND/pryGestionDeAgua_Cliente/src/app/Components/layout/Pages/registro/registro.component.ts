import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { BarrioService } from 'src/app/Services/barrio.service';
import { BarrioInterface } from 'src/app/Interfaces/barrio';
import { RegistroClienteInterface } from 'src/app/Interfaces/registro-cliente';
import { RegistroClienteService } from 'src/app/Services/registro-cliente.service';


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
    private servicioBarrios:BarrioService,
    private servicioRegistroCliente: RegistroClienteService
  ) {
    this.formularioRegistro=this.fb.group({
      dni: ['', Validators.required],
      nombre: ['', Validators.required],
      apellido: ['', Validators.required],
      mail: ['', [Validators.required, Validators.email]],
      password: ['', [Validators.required, Validators.minLength(8)]],
      fechaNacimiento: ['', Validators.required],
      idRol: [1, Validators.required],
      calle: [''],
      piso: [''],
      depto: [''],
      telefono: [''],
      idBarrio: ['', Validators.required],
      sexo: ['',Validators.required],
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
  get idBarrio(){
    return this.formularioRegistro.controls.idBarrio;
  }
  get calle(){
    return this.formularioRegistro.controls.calle;
  }
  get piso(){
    return this.formularioRegistro.controls.piso;
  }
  get telefono(){
    return this.formularioRegistro.controls.telefono;
  }
  get mail(){
    return this.formularioRegistro.controls.mail;
  }
  get pass(){
    return this.formularioRegistro.controls.password;
  }
  get fechaNacimiento(){
    return this.formularioRegistro.controls.fechaNacimiento;
  }
  _error?:string= "";
  _exito?:string= "";
  onSubmit() {
    if (this.formularioRegistro.valid) {
      const registroData: RegistroClienteInterface = this.formularioRegistro.value;
      registroData.dni = registroData.dni.toString();
      this.servicioRegistroCliente.registrarUsuario(registroData)
      .subscribe(
        (respuesta) => {
          this._exito ='Se registro exitosamente',
          setTimeout(() => {
            
            this.router.navigate(['/pages/login'])
          }, 3000);        
        },
        (error) => {
          this._error ='Error algo paso intentelo nuevamente...'
          setTimeout(() => {            
            this._error =''
          }, 3000);
          
        }
      );
    }
  }
  _barrios?:BarrioInterface[];
  traerBarrios(){
    this.servicioBarrios.traerBarrios().subscribe((result)=>{
    this._barrios = result;
    })
  }
}
