import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';
import { ApiService } from '../Api/api.service';

@Injectable({
  providedIn: 'root'
})
export class IniciadoGuard implements CanActivate {
  constructor(private cookieS: CookieService, private router: Router, private _api: ApiService) {

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    const cookie = this.cookieS.check('token');
    if (cookie) {
      this.router.navigate(['/Cargando'])
      this._api.VerificarAuth()
    } 
    return true;
  }
}

