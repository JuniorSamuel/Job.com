import { AgregarPostComponent } from './../../../agregar-post/agregar-post.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';
import { IVacante } from 'src/app/modelo/vacante';
import { DatosService } from 'src/app/servicios/cargar/datos.service';

import Swal from 'sweetalert2';
import { TrabajoDetallesComponent } from 'src/app/vista/trabajo-detalles/trabajo-detalles.component';

@Component({
  selector: 'app-post',
  templateUrl: './post.component.html',
  styleUrls: ['./post.component.css']
})
export class PostComponent implements OnInit {

  
    datoCargada: boolean = true;
    vacantes: IVacante[] = [];
  

    //Table
    displayedColumns: string[] = ['Compañia', 'Posición', 'Ubicación', 'Opciones'];
    dataSource = new MatTableDataSource<IVacante>(this.vacantes);

    //Filtro
    filtro: string = ''

    // MatPaginator Inputs
    length = 100;
    pageSize = 10;
    pageSizeOptions: number[] = [5, 10, 25, 100];
  //#endregion
  constructor(private datos: DatosService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.datos.getVacanteApi();
    this.datos.getVacante().subscribe((respuesta: IVacante[]) =>{
      this.table(respuesta);
    });
  }

  table(usuarios: IVacante[]){
    if(usuarios == []) this.datoCargada = false;
    this.dataSource = new MatTableDataSource<IVacante>(usuarios);
    this.dataSource.paginator = this.paginator;
    
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

  setFiltro(evento: Event) {
    this.dataSource.filter = this.filtro.trim().toLowerCase();
  }
  //PROBANDO MODAL
  onCreate(){
    const dialogConfig = new MatDialogConfig();
    // dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "50%";
    dialogConfig.height = "96%";
    this.dialog.open(AgregarPostComponent,dialogConfig);
  }

  onEditar(vacante: IVacante){
    const dialogConfig = new MatDialogConfig();
    // dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "50%";
    dialogConfig.height = "96%";
    dialogConfig.data = vacante;
    this.dialog.open(AgregarPostComponent,dialogConfig);
  }

  onWacht(vacante: IVacante){
    const dialogConfig = new MatDialogConfig();
    // dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "50%";
    dialogConfig.height = "96%";
    dialogConfig.data = {vacante};
    this.dialog.open(TrabajoDetallesComponent,dialogConfig);
  }
  
  eliminar(id: number){
    // this.datos.deleteVacante(id);
    Swal.fire({
      title: 'Esta seguro que desea eliminarlo?',
      text: "No podra revertir los cambios!",
      icon: 'warning',
      showCancelButton: true,
      confirmButtonColor: '#3085d6',
      cancelButtonColor: '#d33',
      confirmButtonText: 'Si, eliminala!',
      cancelButtonText: 'Cancelar'
    }).then((result) => {
      if (result.isConfirmed) {
        console.log('Selecciono elimiar el ', id);
        this.datos.deleteVacante(id);
        Swal.fire(
          'Eliminado!',
          'Ha sido eliminado.',
          'success'
        )
      }
    })
  }
}
