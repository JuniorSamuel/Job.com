import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IniciadoGuard implements CanActivate {
  constructor(private cookieS: CookieService, private router: Router) {

  }
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {

    const cookie = this.cookieS.check('token');
    if (cookie) {
      this.router.navigate(['/Cargardo'])
    } else {
      return true;
    }
    return false;
  }
}

