import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { CookieService } from 'ngx-cookie-service';
import { IUsuario } from 'src/app/modelo/usuario';
import { IVacante } from 'src/app/modelo/vacante';
import { DatosService } from 'src/app/servicios/cargar/datos.service';
import { AgregarPostComponent } from '../agregar-post/agregar-post.component';
import { TrabajoDetallesComponent } from '../trabajo-detalles/trabajo-detalles.component';

@Component({
  selector: 'app-mis-post',
  templateUrl: './mis-post.component.html',
  styleUrls: ['./mis-post.component.css']
})
export class MisPostComponent implements OnInit {

  //#region Variables
  vacantes: IVacante[];
  usuario: IUsuario;

  //Table
  displayedColumns: string[] = ['Compañia', 'Posición', 'Ubicación', 'Opciones'];
  dataSource = new MatTableDataSource<IVacante>()

  //Filtro
  filtro: string = ''


  // MatPaginator Inputs
  length = 100;
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];


  //#endregion
  constructor(private _datos: DatosService, private dialog: MatDialog, private cookieS: CookieService) {

    this.vacantes = _datos.vacante;
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
    if (this.vacantes.length == 0) {
      console.log('Cero')
      this._datos.getVacanteApi();
      this.getVacante();
    }
    this.tabla(this._datos.vacante);
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
    this._datos.getVacante().subscribe((respuesta: IVacante[]) => {
      this.tabla(respuesta);
    }, (err: any) => {
      console.error(err);
    });
  }

  tabla(v: IVacante[]) {
    this.dataSource = new MatTableDataSource(v.filter(  x => { return x.idUsuario == this.usuario.idUsuario}));
    this.dataSource.paginator = this.paginator
  }

  onWacht(vacante: IVacante) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.autoFocus = true;
    dialogConfig.width = "50%";
    dialogConfig.height = "96%";
    dialogConfig.data = { vacante };
    this.dialog.open(TrabajoDetallesComponent, dialogConfig);
  }

  onCreate() {
    const dialogConfig = new MatDialogConfig();
    // dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "50%";
    dialogConfig.height = "96%";
    this.dialog.open(AgregarPostComponent, dialogConfig);
  }
  
  eliminar(id: number) {
    this._datos.deleteVacante(id);
  }
  
  onEditar(vacante: IVacante) {
    const dialogConfig = new MatDialogConfig();
    // dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "50%";
    dialogConfig.height = "96%";
    dialogConfig.data = vacante;
    this.dialog.open(AgregarPostComponent, dialogConfig);
  }
}

