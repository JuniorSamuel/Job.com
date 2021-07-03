import { TrabajoDetallesComponent } from '../trabajo-detalles/trabajo-detalles.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute, Params } from '@angular/router';
import { IVacante } from 'src/app/modelo/vacante';
import { DatosService } from 'src/app/servicios/cargar/datos.service';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';

@Component({
  selector: 'app-ofertas',
  templateUrl: './ofertas.component.html',
  styleUrls: ['./ofertas.component.css']
})
export class OfertasComponent implements OnInit {

  //#region Variables
  id!: number;
  categoria: string = '';

  vacantes: IVacante[] = [];


  //Table
  displayedColumns: string[] = ['Compañia', 'Posición', 'Ubicación', 'Opciones'];
  dataSource = new MatTableDataSource<IVacante>(this.vacantes)

  //Filtro
  filtro: string = ''

  // MatPaginator Inputs
  length = 100;
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];
  //#endregion

  constructor(private datos: DatosService, private _rutaPametros: ActivatedRoute, private dialog: MatDialog) { }


  ngOnInit(): void {
    this._rutaPametros.params.subscribe((parametro: Params) => {
      this.id = parametro.id;
      this.categoria = parametro.categoria;
    });
    
    this.datos.getVacanteApi();
    this.getVacante();
  }

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator
  }

  // MatPaginator Output
  pageEvent: PageEvent = new PageEvent;
  setPageSizeOptions(setPageSizeOptionsInput: string) {
    if (setPageSizeOptionsInput) {
      this.pageSizeOptions = setPageSizeOptionsInput.split(',').map(str => +str);
    }
  }

  setFiltro() {
    this.dataSource.filter = this.filtro.trim().toLowerCase();
  }

  getVacante() {
    this.datos.getVacante().subscribe((respuesta: IVacante[]) => {
      this.dataSource = new MatTableDataSource(respuesta.filter( ( x) => { return x.idCategoria == this.id}));
      this.dataSource.paginator = this.paginator
    }, (err: any) => {
      console.error(err);
    });
  }
  onWacht(vacante: IVacante){
    const dialogConfig = new MatDialogConfig();
    // dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "50%";
    dialogConfig.height = "96%";
    dialogConfig.data = {vacante: vacante, categoria: this.categoria };
    console.log(vacante.horario)
    this.dialog.open(TrabajoDetallesComponent,dialogConfig);
  }
}
