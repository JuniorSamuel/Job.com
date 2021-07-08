import { AgregarAdministradorComponent } from 'src/app/vista/agregar-administrador/agregar-administrador.component';
import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';
import { IUsuario } from 'src/app/modelo/usuario';
import { ApiService } from 'src/app/servicios/Api/api.service';
import { AdministradorComponent } from '../../administrador.component';
import { DatosService } from 'src/app/servicios/cargar/datos.service';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  datoCargada:boolean = true;

  //Table
  // displayedColumns: string[] = ['Nombre', 'Apellido', 'Edad', 'Acciones'];
  // dataSource = new MatTableDataSource<usuario>(usuarioDatos);
  displayedColumns: string[] = ['nombre', 'correo', 'Acciones'];
  dataSource = new MatTableDataSource<IUsuario>();

  //Filtro
  filtro: string = ''

  // MatPaginator Inputs
  length = 100;
  pageSize = 10;
  pageSizeOptions: number[] = [5, 10, 25, 100];

  
  constructor(private dialog: MatDialog, private datos: DatosService, private padreComp: AdministradorComponent) { 
  }

  @ViewChild(MatPaginator)  paginator!: MatPaginator;

  ngAfterViewInit(): void {
  }


  ngOnInit(): void {
   this.padreComp.getUsuario().subscribe((respuesta: IUsuario[]) => {
     this.table(respuesta.filter(x => {return x.idRol ==2}));
   });
  }

  table(usuarios: IUsuario[]){
    if(usuarios == []) this.datoCargada = false;
    this.dataSource = new MatTableDataSource<IUsuario>(usuarios);
    this.dataSource.paginator = this.paginator;
    
  }

  // MatPaginator Output
  pageEvent: PageEvent = new PageEvent;
  setPageSizeOptions(setPageSizeOptionsInput: string) {
    if (setPageSizeOptionsInput) {
      this.pageSizeOptions = setPageSizeOptionsInput.split(',').map(str => +str);
    }
  }

  setFiltro(){
    this.dataSource.filter = this.filtro.trim().toLowerCase();
  }

  
  onCreate(){
    const dialogConfig = new MatDialogConfig();
    // dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "50%";
    dialogConfig.height = "96%";
    this.dialog.open(AgregarAdministradorComponent,dialogConfig);  
  }

  eliminar(id: number){
    console.log(id)
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
        this.datos.deleteUsuario(id).subscribe( x => {
          this.datos.getUsuariosApi();
          this.datos.getUsuario();

        }, (err: any) => {
          console.error(err);
        });
        Swal.fire(
          'Eliminado!',
          'Ha sido eliminado.',
          'success'
        )
      }
    })
  }

  onDetalle(usuario: IUsuario, editar: boolean){
    const dialogConfig = new MatDialogConfig();
    
    // dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "50%";
    dialogConfig.height = "96%";
    dialogConfig.data = {usuario, editar};
    this.dialog.open(AgregarAdministradorComponent,dialogConfig);  
  } 
}