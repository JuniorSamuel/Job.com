import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { CookieService } from 'ngx-cookie-service';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdmitGuard implements CanActivate {

  constructor(private cookieS: CookieService, private router: Router){}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    
    const rol = parseInt(this.cookieS.get('rol'));

    if(rol == 1){
      return true;
    }else{  
      this.router.navigate(['/Principal']);
    }
    
    return false;
  }
  
}
