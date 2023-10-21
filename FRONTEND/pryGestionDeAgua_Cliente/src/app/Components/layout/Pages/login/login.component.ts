import { Component } from '@angular/core';

import { FormGroup, Validators, FormBuilder } from '@angular/forms';
import { Login } from 'src/app/Interfaces/login';
import { Router } from '@angular/router';
@Component({
  
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
    
})
export class LoginComponent {
  formularioLogin:FormGroup;
  
  ocultarPassword:boolean=true;
  error?:string ="";
  constructor(private fb:FormBuilder,
 
   private router:Router
    ) {
    
    this.formularioLogin = this.fb.group({
      email:['eve.holt@reqres.in',[Validators.required, Validators.email]],
      password:['cityslicka',[Validators.required, Validators.minLength(8)]]
    })
  }
  get email(){
    return this.formularioLogin.controls.email;
  }
  get pass(){
    return this.formularioLogin.controls.password;
  }

  login(){
    if (this.formularioLogin.valid) {
      const formData: Login = this.formularioLogin.value;
      console.log(formData);
    }
    
  }


}
