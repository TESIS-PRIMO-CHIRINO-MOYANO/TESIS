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
  correoElectronico: any;
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
      const usuarioString = localStorage.getItem('user');
      const usuario: User = usuarioString ? JSON.parse(usuarioString) : null;
      this.correoElectronico = usuario ? usuario.mail : null;
      return true;
      
    } else {
      localStorage.removeItem('carrito');
      this.correoElectronico ="";
      return false;
    }
  }
  logout(): void {
    this.isLogged = false;
    this.correoElectronico ="";
    localStorage.removeItem('token');
    localStorage.removeItem('user');
    localStorage.removeItem('usuario');
    localStorage.removeItem('cliente');
    localStorage.removeItem('cuenta');
  }
}
