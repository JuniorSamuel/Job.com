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

  usuariosCargador = [];
  vacantesCargadas: boolean= false;
  categoriasCargadas: boolean = false;
  constructor(private datos: DatosService, private routing: Router) { }

  ngOnInit(): void {
    this.datos.getCategoriasApi();
    this.datos.getVacanteApi();
    this.datos.getRolApi();
    this.getCategoria();
    this.getVacante()

  }
  cargado() {
   if(this.categoriasCargadas && this.vacantesCargadas){
     
      this.routing.navigate(['Principal']);
   }
     
  }

  getCategoria(){
    this.datos.getCategoria().subscribe( (respuesta: ICategoria[]) => {
      this.categoriasCargadas = true;
      console.log(respuesta);
      this.cargado();
      
    });
  }

  getVacante(){
    this.datos.getVacante().subscribe((respuesta: IVacante[]) => {
      this.vacantesCargadas= true;
      console.log(respuesta);
      this.cargado();
    })
  }

}
