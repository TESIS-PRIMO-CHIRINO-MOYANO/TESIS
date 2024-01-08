import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormsModule } from '@angular/forms';
import { Router } from '@angular/router';
import { BarrioService } from 'src/app/Services/barrio.service';
import { BarrioInterface } from 'src/app/Interfaces/barrio';
import { miCuentaInterface } from 'src/app/Interfaces/miCuenta';
import { micuentaService } from 'src/app/Services/miCuenta.service';

@Component({
  selector: 'app-mi-cuenta',
  templateUrl: './mi-cuenta.component.html',
  styleUrls: ['./mi-cuenta.component.css']
})
export class MiCuentaComponent {
  formulariomicuenta:FormGroup;
  ocultarPass:boolean = true;

  constructor(
    private fb:FormBuilder,
    private router:Router,
    private servicioBarrios:BarrioService,
    private serviciomiCuenta: micuentaService
  ) {
    this.formulariomicuenta=this.fb.group({
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
      idBarrio: ['', Validators.required],
      sexo: ['',Validators.required],
    });
  }
  ngOnInit(): void { 
    this.traerBarrios() 
  }
 
   //Getters para los campos de los fomularios
  get nombre(){
    return this.formulariomicuenta.controls.nombre;
  }
  get apellido(){
    return this.formulariomicuenta.controls.apellido;
  }
  get sexo(){
    return this.formulariomicuenta.controls.sexo;
  }
  get dni(){
    return this.formulariomicuenta.controls.dni;
  }
  get idBarrio(){
    return this.formulariomicuenta.controls.idBarrio;
  }
  get calle(){
    return this.formulariomicuenta.controls.calle;
  }
  get piso(){
    return this.formulariomicuenta.controls.piso;
  }
  get telefono(){
    return this.formulariomicuenta.controls.telefono;
  }
  get mail(){
    return this.formulariomicuenta.controls.mail;
  }
  get pass(){
    return this.formulariomicuenta.controls.pass;
  }
  get fechaNacimiento(){
    return this.formulariomicuenta.controls.fechaNacimiento;
  }
  _error?:string= "";
  _exito?:string= "";
  onSubmit() {
    if (this.formulariomicuenta.valid) {
      const registroData: miCuentaInterface = this.formulariomicuenta.value;
      registroData.dni = registroData.dni.toString();
      this.serviciomiCuenta.registrarUsuario(registroData)
      .subscribe(
        (respuesta) => {
          this._exito ='.............',
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
