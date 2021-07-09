import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormGroupName, Validators, FormBuilder  } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { IRol } from 'src/app/modelo/rol';
import { IUsuario } from 'src/app/modelo/usuario';
import { DatosService } from 'src/app/servicios/cargar/datos.service';
import { AdministradorComponent } from '../administrador/administrador.component';

import Swal from 'sweetalert2';
import { CookieService } from 'ngx-cookie-service';

@Component({
  selector: 'app-agregar-administrador',
  templateUrl: './agregar-administrador.component.html',
  styleUrls: ['./agregar-administrador.component.css']
})
export class AgregarAdministradorComponent implements OnInit {

  rol: number;
  habilitar: boolean = true;
  usuario: IUsuario | undefined;
  contrasena: string = '';  

  formUsuario = this.formBuilder.group({
    idUsuario: [''],
    nombre: ['',Validators.required],
    apellido: ['',Validators.required],
    cedula: ['', Validators.required],
    telefono: ['',Validators.required],
    correo: ['', [Validators.required, Validators.email]],
    contrasena1: [''],
    contrasena2: [''],
    // contrasena1: ['',[Validators.required, Validators.minLength(8)]],
    // contrasena2: ['', [Validators.required, Validators.minLength(8)]],
    rol: ['',Validators.required]
  });
  constructor(
    private _cookei: CookieService,
    public dialogRef: MatDialogRef<AgregarAdministradorComponent>,
    private _dato: DatosService,
    @Inject(MAT_DIALOG_DATA) public editar: { usuario: IUsuario, editar: boolean }, private formBuilder: FormBuilder
  ){
    this.rol = parseInt(_cookei.get('ID'));
  }

  ngOnInit(): void {
    if (this.editar != null) {
      this.onEdit();
      if (!this.editar.editar) {
        this.onInavilitar();
        this.habilitar = false;
      }
    } else {
      this.formUsuario.controls['rol'].setValue("2");
      
    }
  }



  onSubmit() {
    if (this.editar == null) {
      if (this.formUsuario.value.contrasena1 == this.formUsuario.value.contrasena2) {

        this.usuario = {
          idUsuario: 0,
          nombre: this.formUsuario.value.nombre,
          apellido: this.formUsuario.value.apellido,
          idRol: this.formUsuario.value.rol,
          cedula: this.formUsuario.value.cedula,
          telefono: this.formUsuario.value.telefono,
          correo: this.formUsuario.value.correo,
          contrasena: this.contrasena
        }
        this._dato.postUsuario(this.usuario);
        Swal.fire(
          'Guardado',
          'Ha sido guardado con exito!',
          'success'
        )
        // Swal.fire({
        //   position: 'top-end',
        //   icon: 'success',
        //   title: 'Ha sido guardado.',
        //   showConfirmButton: false,
        //   timer: 1500
        // })
      }else{
        // alert('Contraseña no coinciden');
        Swal.fire(
          'Contraseñas no coinciden!',
          'Debe coincidir ambas contraseñas.',
          'error'
        )
        // Swal.fire({
        //   position: 'top-end',
        //   icon: 'error',
        //   title: 'Contraseñas no coinciden!',
        //   text: 'Debe confirmar la contraseña.',
        //   showConfirmButton: false,
        //   timer: 2000
        // })
        // this.onSubmit();
      }
    } else {
      this.usuario = {
        idUsuario: this.editar.usuario.idUsuario,
        nombre: this.formUsuario.value.nombre,
        apellido: this.formUsuario.value.apellido,
        idRol: this.formUsuario.value.rol,
        cedula: this.formUsuario.value.cedula,
        telefono: this.formUsuario.value.telefono,
        correo: this.formUsuario.value.correo,
        contrasena: this.contrasena
      }

      console.log(this.usuario)
      Swal.fire({
        title: 'Quiere guardar los cambios?',
        showDenyButton: true,
        showCancelButton: false,
        confirmButtonText: 'Guardar',
        denyButtonText: 'Cancelar',
      }).then((result) => {
        if (result.isConfirmed) {
          this._dato.putUsuario( {
            idUsuario: this.formUsuario.value.idUsuario,
            nombre: this.formUsuario.value.nombre,
            apellido: this.formUsuario.value.apellido,
            idRol: this.formUsuario.value.rol,
            cedula: this.formUsuario.value.cedula,
            telefono: this.formUsuario.value.telefono,
            correo: this.formUsuario.value.correo,
            contrasena: this.contrasena});
          Swal.fire('Editado!', '', 'success')
        } else if (result.isDenied) {
          Swal.fire('Los cambios no se guardaron', '', 'info')
        }
      })
    }
    
    this.onClickNo()
  }

  onClickNo(): void {
    this.dialogRef.close();
  }


  onEdit() {
    this.formUsuario.controls['idUsuario'].setValue(this.editar.usuario.idUsuario);
    this.formUsuario.controls['nombre'].setValue(this.editar.usuario.nombre);
    this.formUsuario.controls['apellido'].setValue(this.editar.usuario.apellido);
    this.formUsuario.controls['rol'].setValue(this.editar.usuario.idRol);
    this.formUsuario.controls['cedula'].setValue(this.editar.usuario.cedula);
    this.formUsuario.controls['telefono'].setValue(this.editar.usuario.telefono);
    this.formUsuario.controls['correo'].setValue(this.editar.usuario.correo);
    this.formUsuario.controls['contrasena1'].setValue(this.editar.usuario.contrasena)
  }

  onInavilitar() {
    this.formUsuario.controls['idUsuario'].disable();
    this.formUsuario.controls['nombre'].disable();
    this.formUsuario.controls['apellido'].disable();
    this.formUsuario.controls['rol'].disable();
    this.formUsuario.controls['cedula'].disable();
    this.formUsuario.controls['telefono'].disable();
    this.formUsuario.controls['correo'].disable();
  }
}
