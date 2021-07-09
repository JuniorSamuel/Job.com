import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ICategoria } from 'src/app/modelo/categoria';
import { IVacante } from 'src/app/modelo/vacante';
import { DatosService } from 'src/app/servicios/cargar/datos.service';
import { AgregarCategoriaComponent } from '../agregar-categoria/agregar-categoria.component';

@Component({
  selector: 'app-trabajo-detalles',
  templateUrl: './trabajo-detalles.component.html',
  styleUrls: ['./trabajo-detalles.component.css']
})
export class TrabajoDetallesComponent implements OnInit {

  id: number;
  categoria!: string;
  vacante!: IVacante;

  temp: ICategoria[]
  constructor(
    public dialogRef: MatDialogRef<AgregarCategoriaComponent>,
    @Inject(MAT_DIALOG_DATA) public detalle: {
      vacante: IVacante
    },
    private datos: DatosService
  ) 
  { 
    this.temp = datos.categorias
    this.id = detalle.vacante.idCategoria
  }

  ngOnInit(): void {
    this.temp = this.temp.filter( x => {return x.idCategoria == this.id})
    console.log('Ok: '+this.temp);
    this.categoria = this.temp[0].nombre;
  }

  onClick(): void{
    this.dialogRef.close();
  }
}
