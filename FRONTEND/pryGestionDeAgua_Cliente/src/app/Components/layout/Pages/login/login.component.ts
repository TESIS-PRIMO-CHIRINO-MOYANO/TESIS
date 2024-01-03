import { Component } from '@angular/core';

import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Login } from 'src/app/Interfaces/login';
import { Router } from '@angular/router';
import { CredencialesLogin } from 'src/app/Interfaces/credenciales-login';
import { AuthService } from 'src/app/Services/auth.service';

@Component({

  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],

})
export class LoginComponent {
  formularioLogin: FormGroup;

  ocultarPassword: boolean = true;
  error?: string = "";
  constructor(private fb: FormBuilder,
    private authService: AuthService,
    private router: Router,

  ) {

    this.formularioLogin = this.fb.group({
      mail: ['Upruebas@gmail.com', [Validators.required, Validators.email]],
      password: ['prueba', [Validators.required, Validators.minLength(6)]]
    })
  }
  get mail() {
    return this.formularioLogin.controls.mail;
  }
  get pass() {
    return this.formularioLogin.controls.password;
  }

  _error?: string = "";


  login(): void {
    if (this.formularioLogin.valid) {
      const formData: CredencialesLogin = this.formularioLogin.value;
      console.log(formData);
      this.authService.login(formData).subscribe(
        (response) => {
          console.log(response);
          if (response.isSucces) {
            localStorage.setItem('token', response.result.token);
            localStorage.setItem('usuario', JSON.stringify(response.result.usuario));
            localStorage.setItem('cliente', JSON.stringify(response.result.cliente));
            localStorage.setItem('cuenta', JSON.stringify(response.result.cuenta));
            window.location.href = "/pages";
          } else {

          }
        },
        (error) => {
          console.log(error);
          if (error.error.statusCode == 400) {
            this._error = 'Usuario y/o contraeña incorrecta...';
          } else {
            this._error = 'Error en el servidor contactenos...';
          }
        }
      );
    }

  }





}
