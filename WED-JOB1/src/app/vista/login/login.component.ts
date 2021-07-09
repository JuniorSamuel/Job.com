import { RegistrarComponent } from './../registrar/registrar.component';
import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/servicios/Api/api.service';
import { ILogin } from 'src/app/modelo/login';
import { ILoginRespuesta } from 'src/app/modelo/login-respuesta';
import { CookieService } from 'ngx-cookie-service';
import { FormBuilder, Validators } from '@angular/forms';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})

export class LoginComponent implements OnInit {

  //#region Variable

  loginForm = this._formBuilder.group({
    correo: ['', Validators.required],
    contrasena: ['', Validators.required]
  });
  //#endregion


  constructor(
    private _formBuilder: FormBuilder,
    private _dialog: MatDialog,
    private _rout: Router,
    private _api: ApiService,
    private _cookie: CookieService
  ) { }

  ngOnInit(): void {
  }
  onCreate(){
    const dialogConfig = new MatDialogConfig();
    // dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "50%";
    dialogConfig.height = "96%";
    this._dialog.open(RegistrarComponent,dialogConfig);  
  }

  login(){
    console.log( {correo: this.loginForm.value.correo, contrasena: this.loginForm.value.contrasena})
    this._api.login({ correo: this.loginForm.value.correo, contrasena: this.loginForm.value.contrasena}).subscribe((respuesta: ILoginRespuesta) => {
      if (respuesta.exito == 1) {
              this._cookie.set('token', respuesta.data.token);
        this._cookie.set('ID', respuesta.data.idUsuario+'');
        this._cookie.set('nombre', respuesta.data.nombre);
        this._cookie.set('apellido', respuesta.data.apellido)
        this._cookie.set('cedula', respuesta.data.cedula+'');
        this._cookie.set('telefono', respuesta.data.telefono+'');
        this._cookie.set('correo', respuesta.data.correo);
        this._cookie.set('rol', respuesta.data.idRol+'')
        this._cookie.set('fila', '10');
        this._rout.navigate(['Cargando']);
      } else {
        // alert(respuesta.mensaje);
        this.alertBothIncorrect();
      }
    }, (err: any) => {
      console.log('respuesta error');
      // this.alertBothIncorrect();
      console.error(err);
    });
  }
  alertPasswordIncorrect(){
    Swal.fire(
      'Contraseña Incorrecta!',
      'Debe ingresar una contraseña valida!',
      'error',
    )
  }
  alertUserIncorrect(){
    Swal.fire(
      'Usuario Incorrecto!',
      'Debe ingresar un Usuario valido!',
      'error',
    )
  }
  alertBothIncorrect(){
    Swal.fire(
      'Usuario y/o Contraseña Incorrectos!',
      'Debe ingresar un Usuario y una Contraseña validos!',
      'error',
    )
  }

}
