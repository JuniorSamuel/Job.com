import { HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Observable, Subject } from 'rxjs';
import { ICategoria } from 'src/app/modelo/categoria';
import { IRol } from 'src/app/modelo/rol';
import { IUsuario } from 'src/app/modelo/usuario';
import { IVacante } from 'src/app/modelo/vacante';
import { ApiService } from '../Api/api.service';

@Injectable({
  providedIn: 'root'
})
export class DatosService {
  
  
  //#region Variavles
  public usuarios: IUsuario[];
  public categorias: ICategoria[];
  public vacante: IVacante[];
  public rol: IRol[];

  private usuarios$: Subject<IUsuario[]>;
  private categorias$: Subject<ICategoria[]>;
  private vacante$: Subject<IVacante[]>;
  private rol$: Subject<IRol[]>;
private userVal$: Subject<boolean>;
  public auth: boolean;
  userVal: boolean;

  //#endregion
  constructor(private _api: ApiService, private _cookie: CookieService, private router: Router) { 
    this.categorias = [];
    this.usuarios = [];
    this.vacante = [];
    this.rol = [];
  
    this.usuarios$ = new Subject();
    this.categorias$ = new Subject();
    this.vacante$= new Subject();
    this.rol$ = new Subject();
    this.userVal$ =new Subject();

    this.auth = true;
    this.userVal =false;
  }

  cargar() {
    this.getCategoriasApi();
    this.getVacanteApi();
  }
  
  //Verificar
  verificarAuth(): boolean{
    this._api.VerificarAuth().subscribe( x => {
      this.auth = x;      
    },(err: HttpErrorResponse) => {
      if (err.status === 401) {
        this._cookie.deleteAll();
        this.router.navigate(['/Login'])
        this.auth = false;      
      }
    });
    return this.auth;
  }
  //Cookei
  getUsuarioCookei(): IUsuario{
    var usuario: IUsuario = {
      idUsuario: parseInt(this._cookie.get('ID')),
      nombre: this._cookie.get('nombre'),
      apellido: this._cookie.get('apellido'),
      cedula: parseInt(this._cookie.get('cedula')),
      telefono: parseInt(this._cookie.get('telefono')),
      correo: this._cookie.get('correo'),
      idRol: parseInt(this._cookie.get('rol')),
      contrasena: ''
    }

    return usuario;
  }

  setUsuarioCookei(data: any): void{
    this._cookie.set('token', data.token);
    this._cookie.set('ID', data.idUsuario+'');
    this._cookie.set('nombre', data.nombre);
    this._cookie.set('apellido', data.apellido)
    this._cookie.set('cedula', data.cedula+'');
    this._cookie.set('telefono', data.telefono+'');
    this._cookie.set('correo', data.correo);
    this._cookie.set('rol', data.idRol+'')
  }

  deleteCookie(){
    this._cookie.deleteAll();
  }
  //Api
  getUsuariosApi() {
    this._api.getUsuarios().subscribe((respuesta: any) => {
      this.usuarios = respuesta.dato;
      this.usuarios$.next(this.usuarios);
    }, (err: any) => {
      console.error(err);
    });
  }

  getCategoriasApi() {
    this._api.getCategorias().subscribe((respuesta: ICategoria[]) => {
      this.categorias = respuesta;
      this.categorias$.next(this.categorias);
    }, (err: any) => {
      console.error(err);
    });
  }

  getVacanteApi(){
    this._api.getVacantes().subscribe((respuesta: IVacante[]) => {
      this.vacante = respuesta;
      this.vacante$.next(this.vacante);
    }, (err: any) =>{
      console.error(err);
    });
  }

  getRolApi(){
    this._api.getRol().subscribe((respuesta: IRol[]) =>{
      this.rol = respuesta;
      this.rol$.next(this.rol);
    }, (err: any) => {
      console.error(err);
    });
  }

  getUsuario(): Observable<IUsuario[]> {
    return this.usuarios$.asObservable();
  }

  getCategoria(): Observable<ICategoria[]> {
    return this.categorias$.asObservable();
  }

  getVacante(): Observable<IVacante[]>{
    return this.vacante$.asObservable();
  }

  getRol(): Observable<IRol[]> {
    return this.rol$.asObservable();
  }

  postVacante(vacante: IVacante){
    console.log(vacante);
    this._api.postVacante(vacante).subscribe((vacante: IVacante) =>{
      this.vacante.push(vacante);
      this.vacante$.next(this.vacante);
    }, (err: any) =>{
      console.error(err);
    });
  }

  postCategoria(categoria: ICategoria){
    this._api.postCategoria(categoria).subscribe((categoria: ICategoria) =>{
      this.categorias.push(categoria);
      this.categorias$.next(this.categorias);
    }, (err: any) =>{
      console.error(err);
    });
  }

  postUsuario(usuario: IUsuario){
    this._api.postUsuario(usuario).subscribe((usuario: IUsuario) => {
      this.usuarios.push(usuario);
      this.usuarios$.next(this.usuarios)
    }, (err: any) => {
      console.error(err)
    })
  }

  deleteCategoria(id: number): Observable<any>{
    return this._api.deleteCategoria(id)
  }

  deleteUsuario(id: number): Observable<any>{
    return this._api.deleteUsuario(id)
  }

  deleteVacante(id: number): Observable<any> {
    return this._api.deletePost(id);
  }
  
  putCategoria(categoria: ICategoria){
    this._api.putCategoria(categoria).subscribe(x => {
      this.getCategoriasApi();
    }, (err: any) => {
      console.error(err)
    })
  }

  putUsuario(usuario: IUsuario) {
   this._api.putUsuario(usuario).subscribe(x => {
      this.getUsuariosApi();
   }, (err: any) => {
     console.error(err)
   })
  }

  putVacante(vacante: IVacante) {
    console.log(vacante);
    this._api.putVacante(vacante).subscribe(x => {
      this.getVacanteApi()
    }, (err: any) => {
      console.error(err)
    })
   }
 }