import { AgregarAdministradorComponent } from 'src/app/vista/agregar-administrador/agregar-administrador.component';

import { Parser } from '@angular/compiler/src/ml_parser/parser';
import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { IUsuario } from 'src/app/modelo/usuario';

import {MatDialog, MatDialogConfig} from '@angular/material/dialog';
import { DatosService } from 'src/app/servicios/cargar/datos.service';

@Component({
  selector: 'app-perfil',
  templateUrl: './perfil.component.html',
  styleUrls: ['./perfil.component.css']
})
export class PerfilComponent implements OnInit {
  //
  usuario: IUsuario;  
  constructor(private cookieS: CookieService,private datos: DatosService, private dialog: MatDialog) {
    this.usuario = {
      idUsuario: parseInt(this.cookieS.get('ID')),
      nombre: cookieS.get('nombre'), 
      apellido: cookieS.get('apellido'), 
      telefono: parseInt(this.cookieS.get('telefono')),
      cedula: parseInt(this.cookieS.get('cedula')),
      idRol: parseInt(this.cookieS.get('rol')),
      correo: this.cookieS.get('correo'),
      contrasena: 'null'
    }
   }

  ngOnInit(): void {
  }
  onDetalle(){
    const dialogConfig = new MatDialogConfig();
    // dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "50%";
    dialogConfig.height = "96%";
    dialogConfig.data = {usuario: this.usuario, editar: true};
    this.dialog.open(AgregarAdministradorComponent,dialogConfig);  
  }
}
