import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ICategoria } from 'src/app/modelo/categoria';
import { ILogin } from 'src/app/modelo/login';
import { ILoginRespuesta } from 'src/app/modelo/login-respuesta';
import { IRol } from 'src/app/modelo/rol';
import { IUsuario } from 'src/app/modelo/usuario';
import { IVacante } from 'src/app/modelo/vacante';

const httpOptions = {
  headers: new HttpHeaders({ 
    'Access-Control-Allow-Origin':'*',
    'Authorization':'authkey',
    'userid':'1'
  })
};

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  

  constructor(private _http: HttpClient) { }

  private _host: string = 'https://api-job.azurewebsites.net/';

  //GET ALL
  getCategorias(): Observable<ICategoria[]>{
    return this._http.get<ICategoria[]>(this._host +'api/Categoria');
  }

  getVacantesPorCategorias(idCategoria: number): Observable<IVacante[]>{
    return this._http.get<IVacante[]>(this._host +'api/Vacante/FiltroPorCategoria/'+idCategoria);
  }

  getVacantes(): Observable<IVacante[]>{
    return this._http.get<IVacante[]>(this._host+'api/Vacante');
  }

  getUsuarios(): Observable<any>{
    return this._http.get<any[]>(this._host +'api/Usuario');
  }

  getRol(): Observable<IRol[]> {
    return this._http.get<IRol[]>(this._host+ "api/Rol")
  }

  //Post

  postCategoria(categoria: ICategoria): Observable<ICategoria>{
    return this._http.post<ICategoria>(this._host+ 'api/Categoria', categoria)
  }

  postVacante(vacante: IVacante): Observable<IVacante>{
    return this._http.post<IVacante>(this._host+"api/Vacante", vacante);
  }

  postUsuario(usuario: IUsuario): Observable<IUsuario>{
    return this._http.post<IUsuario>(this._host+'api/Usuario', usuario);
  }

  login(user: ILogin): Observable<ILoginRespuesta>{
    return this._http.post<ILoginRespuesta>(this._host + "api/Login/login", user);
  }

  //Delete
  deleteCategoria(id: number): Observable<any>{
    return this._http.delete(this._host + "api/Categoria?CategoriaId=" + id);
  }

  deletePost(id: number): Observable<any>{
    return this._http.delete(this._host+'api/Vacante?VacanteId=' + id,{responseType: 'text' })
  }

  deleteUsuario(id: number): Observable<any>{
    return this._http.delete(this._host+'api/Usuario?UsuarioId=' + id, {responseType: 'text' })
  }

  //Put
  putCategoria(categoria: ICategoria): Observable<any>{
    return this._http.put(this._host+'api/Categoria', categoria);
  }

  putUsuario(usuario: IUsuario) {
    return this._http.put(this._host+ 'api/Usuario', usuario)
  }

  putVacante(vacante: IVacante) {
    return this._http.put(this._host+ 'api/Vacante', vacante)
  }

}

