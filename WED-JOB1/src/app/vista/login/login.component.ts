import { RegistrarComponent } from './../registrar/registrar.component';
import { Component, OnInit } from '@angular/core';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';
import { Router } from '@angular/router';
import { ApiService } from 'src/app/servicios/Api/api.service';
import { ILogin } from 'src/app/modelo/login';
import { ILoginRespuesta } from 'src/app/modelo/login-respuesta';
import { CookieService } from 'ngx-cookie-service';
import { FormBuilder, Validators } from '@angular/forms';

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
    dialogConfig.width = "55%";
    // dialogConfig.height = "20%";
    this._dialog.open(RegistrarComponent,dialogConfig);  
  }

  login(){
    
    this._api.login({ correo: this.loginForm.value.correo, contrasena: this.loginForm.value.contrasena}).subscribe((respuesta: ILoginRespuesta) => {
      if (respuesta.exito == 1 || respuesta ==null) {
              this._cookie.set('token', respuesta.data.token);
        this._cookie.set('ID', respuesta.data.idUsuario+'');
        this._cookie.set('nombre', respuesta.data.nombre);
        this._cookie.set('cedula', respuesta.data.cedula+'');
        this._cookie.set('telefono', respuesta.data.telefono+'');
        this._cookie.set('correo', respuesta.data.correo);
        this._cookie.set('rol', respuesta.data.idRol+'')
        this._rout.navigate(['Cargardo']);
      } else {
        alert(respuesta.mensaje);
      }
    }, (err: any) => {
      console.error(err);
    });
  }

}
