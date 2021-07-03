import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator, PageEvent } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ICategoriaVacante } from 'src/app/modelo/categoriaVacante';
import { IVacante } from 'src/app/modelo/vacante';
import { ApiService } from 'src/app/servicios/Api/api.service';
import { DatosService } from 'src/app/servicios/cargar/datos.service';
import {MatDialog, MatDialogConfig} from '@angular/material/dialog';
import { TrabajoDetallesComponent } from '../trabajo-detalles/trabajo-detalles.component';
import { ICategoria } from 'src/app/modelo/categoria';


@Component({
  selector: 'app-principal',
  templateUrl: './principal.component.html',
  styleUrls: ['./principal.component.css']
})

export class PrincipalComponent implements OnInit, AfterViewInit {

  //#region Variables    
    datoCargada = false;
    categorias: ICategoriaVacante[] = [];
    cat: ICategoria[] =  [];
    vacantes: IVacante[] = [];
    fila: number = 10;
    
    displayedColumns: string[] = ['Compañia', 'Posición', 'Ubicación', 'Opciones'];
    dataSource = new MatTableDataSource<IVacante>(this.vacantes)    
    
    //Filtro
    filtro: string = ''

    // MatPaginator Inputs
    length = 100;
    pageSize = 10;
    pageSizeOptions: number[] = [5, 10, 25, 100];
  //#endregion

  constructor(private datos: DatosService, private dialog: MatDialog) { }


  @ViewChild(MatPaginator)  paginator!: MatPaginator;
  
  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator
  }

  ngOnInit(): void {
    this.datos.getCategoriasApi();
    this.getCategoria();
    this.datos.getVacanteApi();

  }
  
  // MatPaginator Output
  pageEvent: PageEvent = new PageEvent;
  setPageSizeOptions(setPageSizeOptionsInput: string) {
    if (setPageSizeOptionsInput) {
      this.pageSizeOptions = setPageSizeOptionsInput.split(',').map(str => +str);
    }
  }

  setFiltro(){
    //this.dataSource.filter = this.filtro.trim().toLowerCase();
    this.categorias.find
  }

  getCategoria(){
    this.datos.getCategoria().subscribe( (respuesta: ICategoria[]) => {
      this.getVacante();
      this.cat = respuesta;      
    });
  }

  getVacante(){
    this.datos.getVacante().subscribe((respuesta: IVacante[]) => {
      this.vacantes  =respuesta;
    })
  }

  filtroVacante(num: number){
    console.log('OK');
    return this.vacantes.filter(x => { x.idCategoria == num});
  }

  onWacht(vacante: IVacante, categoria: string){
    const dialogConfig = new MatDialogConfig();
    // dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "50%";
    dialogConfig.height = "96%";
    dialogConfig.data = {vacante, categoria};
    this.dialog.open(TrabajoDetallesComponent,dialogConfig);
  }
}


