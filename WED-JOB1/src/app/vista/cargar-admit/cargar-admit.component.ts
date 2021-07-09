import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ICategoria } from 'src/app/modelo/categoria';
import { IUsuario } from 'src/app/modelo/usuario';
import { IVacante } from 'src/app/modelo/vacante';
import { ApiService } from 'src/app/servicios/Api/api.service';
import { DatosService } from 'src/app/servicios/cargar/datos.service';

@Component({
  selector: 'app-cargar-admit',
  templateUrl: './cargar-admit.component.html',
  styleUrls: ['./cargar-admit.component.css']
})
export class CargarAdmitComponent implements OnInit {

  //#region Variables
  usuariosCargadas: boolean;
  vacantesCargadas: boolean;
  categoriasCargadas: boolean;
  usuarioValido: boolean;
  //#endregion

  constructor(
    private _datos: DatosService,
    private _router: Router,
    private _api: ApiService
  ) {
    this.usuariosCargadas = false;
    this.vacantesCargadas = false;
    this.categoriasCargadas = false;
    this.usuarioValido = _datos.userVal
  }

  ngOnInit(): void {

    this._api.VerificarUser(this._datos.getUsuarioCookei()).subscribe((respuesta: boolean) => {
      this._datos.userVal = respuesta;
      if(respuesta) {
        this.cargado()
      }else {
        this._datos.deleteCookie();
        this._router.navigate(['Login']);
      }
    });
    
    if(this._datos.categorias != []){
      this._datos.getCategoriasApi();
      this.getCategoria();
    }

    if(this._datos.vacante != []){
      this._datos.getVacanteApi();
      this.getVacante();
    }

    if(this._datos.rol != []){
      this._datos.getRolApi();
    }

    if(this._datos.usuarios != []){
      this._datos.getUsuariosApi();
      this.getUsuario();
    }

    this.cargado();
  }

  cargado() {
    if (this.categoriasCargadas && this.vacantesCargadas && this.usuariosCargadas && this._datos.userVal) {
      this._router.navigate(['Administrador']);
    }
  }

  getUsuario(){
    this._datos.getUsuario().subscribe((respuesta: IUsuario[]) => {
      this.usuariosCargadas = true;
      this.cargado();
    });
  }

  getCategoria() {
    this._datos.getCategoria().subscribe((respuesta: ICategoria[]) => {
      this.categoriasCargadas = true;
      this.cargado();
    });
  }

  getVacante() {
    this._datos.getVacante().subscribe((respuesta: IVacante[]) => {
      this.vacantesCargadas = true;
      this.cargado();
    })
  }
}
