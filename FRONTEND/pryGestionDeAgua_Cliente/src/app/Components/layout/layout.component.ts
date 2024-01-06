import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from 'src/app/Interfaces/login-respuesta';

@Component({
  selector: 'app-layout',
  templateUrl: './layout.component.html',
  styleUrls: ['./layout.component.css']
})
export class LayoutComponent {
  
  isLogged:boolean = false;
  nombre: any;
  constructor(private router: Router) {
    this.isLogged = this.isLoggedIn();
  }

  navegarAConsultaCUenta(): void {
    // Navega al componente y recarga la página
    window.location.href = "/pages/consultarCuenta";
  }


  
  isLoggedIn(): boolean {
  const userToken = localStorage.getItem('token');
    if (userToken !== null) {
      const usuarioString = localStorage.getItem('usuario');
      const usuario: User = usuarioString ? JSON.parse(usuarioString) : null;
      this.nombre = usuario ? usuario.nombre + " " + usuario.apellido : null;

      return true;
      
    } else {
      localStorage.removeItem('carrito');
      this.nombre ="";
      return false;
    }
  }
  logout(): void {
    this.isLogged = false;
    this.nombre ="";
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    localStorage.removeItem('usuario');
    localStorage.removeItem('cliente');
    localStorage.removeItem('cuenta');
    window.location.href = "/pages/inicio";
  }
}
