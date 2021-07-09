import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ICategoria } from 'src/app/modelo/categoria';
import { IVacante } from 'src/app/modelo/vacante';
import { DatosService } from 'src/app/servicios/cargar/datos.service';

@Component({
  selector: 'app-cargar',
  templateUrl: './cargar.component.html',
  styleUrls: ['./cargar.component.css']
})
export class CargarComponent implements OnInit {

  //#region Variables
  usuariosCargador = [];
  vacantesCargadas: boolean = false;
  categoriasCargadas: boolean = false;
  //#endregion

  constructor(
    private _datos: DatosService,
    private _routing: Router
  ) { }

  ngOnInit(): void {
    this._datos.getCategoriasApi();
    this._datos.getVacanteApi();
    this._datos.getRolApi();
    this.getCategoria();
    this.getVacante()

  }

  cargado() {
    if (this.categoriasCargadas && this.vacantesCargadas) {
      this._routing.navigate(['Principal']);
    }
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
