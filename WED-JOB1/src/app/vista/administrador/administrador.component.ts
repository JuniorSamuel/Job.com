import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, Subject } from 'rxjs';
import { ICategoria } from 'src/app/modelo/categoria';
import { IRol } from 'src/app/modelo/rol';
import { IUsuario } from 'src/app/modelo/usuario';
import { IVacante } from 'src/app/modelo/vacante';
import { DatosService } from 'src/app/servicios/cargar/datos.service';

@Component({
  selector: 'app-administrador',
  templateUrl: './administrador.component.html',
  styleUrls: ['./administrador.component.css']
})
export class AdministradorComponent implements OnInit {

  usuarios: IUsuario[] = [];
  categorias: ICategoria[];
  vacantes: IVacante[];
  private observador$: Subject<IUsuario[]> = new Subject();
  rol: IRol[] = [];

  constructor(
    private _datos: DatosService,
    private _router: Router
  ) {
    this.categorias = _datos.categorias;
    this.vacantes = _datos.vacante;
    this.usuarios = _datos.usuarios;
    this.rol = _datos.rol;
    this.observador$ = new Subject()
  }

  ngOnInit(): void {
    if(this.categorias.length == 0 || this.vacantes.length == 0 || this.usuarios.length == 0){
      this._router.navigate(['Cargando_Administrador']);
    }
    
    this._datos.getUsuariosApi()
    if (this.usuarios.length == 0) {
      this._datos.getUsuariosApi();
      this._datos.getUsuario().subscribe((respuesta: IUsuario[]) => {
        this.usuarios = respuesta;
      });
    }
    this.observador$.next(this.usuarios);
  }

  getUsuario(): Observable<IUsuario[]> {
    return this.observador$.asObservable();
  }
}
