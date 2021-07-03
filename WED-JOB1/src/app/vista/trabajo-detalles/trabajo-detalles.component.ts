import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IVacante } from 'src/app/modelo/vacante';
import { AgregarCategoriaComponent } from '../agregar-categoria/agregar-categoria.component';

@Component({
  selector: 'app-trabajo-detalles',
  templateUrl: './trabajo-detalles.component.html',
  styleUrls: ['./trabajo-detalles.component.css']
})
export class TrabajoDetallesComponent implements OnInit {

  categoria!: string;
  vacante!: IVacante;
  constructor(public dialogRef: MatDialogRef<AgregarCategoriaComponent>,  @Inject(MAT_DIALOG_DATA) public detalle: {vacante: IVacante, categoria: string}) { }

  ngOnInit(): void {
   
  }

}
