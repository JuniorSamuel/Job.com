import { Parser } from '@angular/compiler/src/ml_parser/parser';
import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { IUsuario } from 'src/app/modelo/usuario';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {
  //
  usuario: IUsuario;  
  constructor(private cookieS: CookieService) {
    this.usuario = {
      idUsuario: parseInt(this.cookieS.get('ID')),
      nombre: cookieS.get('nombre'), 
      apellido: 'No carga', 
      telefono: parseInt(this.cookieS.get('telefono')),
      cedula: parseInt(this.cookieS.get('cedula')),
      idRol: parseInt(this.cookieS.get('rol')),
      correo: this.cookieS.get('correo'),
      contrasena: 'null'
    }
   }

  ngOnInit(): void {
  }

}
