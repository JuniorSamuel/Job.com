import { Component, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { AgregarPostComponent } from 'src/app/vista/agregar-post/agregar-post.component';

@Component({
  selector: 'app-navegacion',
  templateUrl: './navegacion.component.html',
  styleUrls: ['./navegacion.component.css']
})
export class NavegacionComponent implements OnInit {

  rol: number;
  usuario: string;
  constructor(private _dialog: MatDialog, private _cookieS: CookieService, private _router: Router) {
    this.rol = parseInt(_cookieS.get('rol'));
    this.usuario = _cookieS.get('nombre')
   }

  ngOnInit(): void {
  }

  onCreate(){
    const dialogConfig = new MatDialogConfig();
    // dialogConfig.disableClose = true;
    dialogConfig.autoFocus = true;
    dialogConfig.width = "50%";
    dialogConfig.height = "96%";
    this._dialog.open(AgregarPostComponent,dialogConfig);
  }

  admit(){
    this._router.navigate(['Administrador'] )
  }

  mis_post(){
    this._router.navigate(['PerfilU'])
  }

  salir(){
    this._cookieS.deleteAll()
    this._router.navigate(['/Login']);
  }

}
