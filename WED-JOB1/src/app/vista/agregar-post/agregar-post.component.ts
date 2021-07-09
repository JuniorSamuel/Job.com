import { Component, OnInit, Inject } from '@angular/core';
import { FormControl, FormGroup, Validators, FormBuilder } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { CookieService } from 'ngx-cookie-service';
import { ICategoria } from 'src/app/modelo/categoria';
import { IVacante } from 'src/app/modelo/vacante';
import { DatosService } from 'src/app/servicios/cargar/datos.service';

import Swal from 'sweetalert2';

@Component({
  selector: 'app-agregar-post',
  templateUrl: './agregar-post.component.html',
  styleUrls: ['./agregar-post.component.css']
})
export class AgregarPostComponent implements OnInit {

  //#region Variables
  id: number = 0;
  vacante: IVacante | undefined;
  categoria: ICategoria[];
  //#endregion

  postForm = this.formBuilder.group({
    idCategoria: ['', Validators.required],
    campania: ['', Validators.required],
    posicion: ['', Validators.required],
    descripcion: ['', [Validators.required, Validators.maxLength(80)]],
    telefono: ['', [Validators.required, Validators.minLength(10), Validators.maxLength(20)]],
    correo: ['', [Validators.required, Validators.email]],
    horario: ['', Validators.required],
    ubicacion: ['', Validators.required],
    idUsuario: [],
    fecha: []
  });

  constructor(
    public dialogRef: MatDialogRef<AgregarPostComponent>,
    private _datos: DatosService,
    @Inject(MAT_DIALOG_DATA) public editar: IVacante,
    private formBuilder: FormBuilder,
    private cookies: CookieService
  ) {
    this.categoria = _datos.categorias;
  }

  ngOnInit(): void {
    if (this.editar != null) {
      this.onEdit();
    } else {
      this.postForm.controls['horario'].setValue('Tiempo completo');
    }
  }

  onSubmit() {

    if (this.editar == null) {
      this.id = parseInt(this.cookies.get('ID'));
      this._datos.postVacante({
        idVacante: 0,
        idCategoria: this.postForm.value.idCategoria,
        compania: this.postForm.value.campania,
        posicion: this.postForm.value.posicion,
        descripcion: this.postForm.value.descripcion,
        telefono: this.postForm.value.telefono,
        correo: this.postForm.value.correo,
        horario: this.postForm.value.horario,
        ubicacion: this.postForm.value.ubicacion,
        idUsuario: this.id,
        fecha: new Date()
      });
      Swal.fire({
        position: 'top-end',
        icon: 'success',
        title: 'Ha sido guardado.',
        showConfirmButton: false,
        timer: 1500
      });
    } else {
      Swal.fire({
        title: 'Quiere guardar los cambios?',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Guardar',
        denyButtonText: 'Cancelar',
      }).then((result) => {
        if (result.isConfirmed) {
          this._datos.putVacante({
            idVacante: this.postForm.value.idCategoria,
            idCategoria: this.postForm.value.idCategoria,
            compania: this.postForm.value.campania,
            posicion: this.postForm.value.posicion,
            descripcion: this.postForm.value.descripcion,
            telefono: this.postForm.value.telefono,
            correo: this.postForm.value.correo,
            horario: this.postForm.value.horario,
            ubicacion: this.postForm.value.ubicacion,
            idUsuario: this.postForm.value.idUsuario,
            fecha: this.postForm.value.fecha
          });

          Swal.fire('Editado!', '', 'success')
        } else if (result.isDenied) {
          Swal.fire('Los cambios no se guardaron', '', 'info')
        }
      });
    }

    this.onClickNo()
  }

  onClickNo(): void {
    this.dialogRef.close();
  }

  onEdit() {
    this.postForm.controls['idCategoria'].setValue(this.editar.idCategoria);
    this.postForm.controls['campania'].setValue(this.editar.compania);
    this.postForm.controls['posicion'].setValue(this.editar.posicion);
    this.postForm.controls['descripcion'].setValue(this.editar.descripcion);
    this.postForm.controls['telefono'].setValue(this.editar.telefono);
    this.postForm.controls['correo'].setValue(this.editar.correo);
    this.postForm.controls['horario'].setValue(this.editar.horario);
    this.postForm.controls['ubicacion'].setValue(this.editar.ubicacion);
    this.postForm.controls['idUsuario'].setValue(this.editar.idUsuario);
    this.postForm.controls['fecha'].setValue(this.editar.fecha)
  }
}
