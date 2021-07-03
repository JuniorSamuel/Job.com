import { ReturnStatement } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { ICategoria } from 'src/app/modelo/categoria';
import { IRol } from 'src/app/modelo/rol';
import { IUsuario } from 'src/app/modelo/usuario';
import { IVacante } from 'src/app/modelo/vacante';
import { ApiService } from 'src/app/servicios/Api/api.service';
import { DatosService } from 'src/app/servicios/cargar/datos.service';

@Component({
  selector: 'app-administrador',
  templateUrl: './administrador.component.html',
  styleUrls: ['./administrador.component.css']
})
export class AdministradorComponent implements OnInit {

  usuarios:IUsuario[] = [];
  private observador$: Subject<IUsuario[]>;
  rol: IRol[] = [];

  constructor(private _datos: DatosService) { 
    this.observador$ = new Subject()
  }

  ngOnInit(): void {
        this._datos.getUsuariosApi();
        this._datos.getUsuario().subscribe((respuesta: IUsuario[]) => {
          this.usuarios = respuesta;
          this.observador$.next(this.usuarios)
        })
  }

  getUsuario(): Observable<IUsuario[]> {
    return this.observador$.asObservable();
  }

  getRol() {
    this._datos.getRol().subscribe((respuesta: IRol[]) => {
      this.rol = respuesta;
      console.log(this.rol)
    }, (err: any) => {
        console.error(err)
    }); 
  }
}
