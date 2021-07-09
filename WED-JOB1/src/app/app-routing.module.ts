import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NavegacionComponent } from './compomente/navegacion/navegacion.component';
import { AgregarPostComponent } from './vista/agregar-post/agregar-post.component';

import { LoginComponent } from './vista/login/login.component';
import { PrincipalComponent } from './vista/principal/principal.component';
import { PieComponent } from './compomente/pie/pie.component';
import { AdministradorComponent } from './vista/administrador/administrador.component';

import { PerfilComponent } from './vista/perfil/perfil.component';
import { TrabajoDetallesComponent } from './vista/trabajo-detalles/trabajo-detalles.component';
import { OfertasComponent } from './vista/ofertas/ofertas.component';
import { CargarComponent } from './vista/cargar/cargar.component';
import { MisPostComponent } from './vista/mis-post/mis-post.component';
import { UserGuardGuard } from './servicios/guard/user-guard.guard';
import { IniciadoGuard } from './servicios/guard/iniciado.guard';
import { AdmitGuard } from './servicios/guard/admit.guard';
import { PostGuard } from './servicios/guard/post.guard';
import { CargarAdmitComponent } from './vista/cargar-admit/cargar-admit.component';

const routes: Routes = [
  { path: '', redirectTo: 'Login', pathMatch: 'full' },
  { path: "Login", component: LoginComponent, canActivate: [IniciadoGuard]},
  { path: "Principal", component: PrincipalComponent, canActivate: [UserGuardGuard]},  
  { path: "Ofertas/:id/:categoria", component: OfertasComponent, canActivate: [UserGuardGuard]},
  { path: "Vacante", component: TrabajoDetallesComponent, canActivate: [UserGuardGuard]},
  { path: "Cargando", component: CargarComponent, canActivate: [UserGuardGuard]},
  { path: "Mis_post", component: MisPostComponent, canActivate: [UserGuardGuard]},
  { path: "Agregar_post", component: AgregarPostComponent, canActivate: [UserGuardGuard, PostGuard]},
  { path: "Administrador", component: AdministradorComponent, canActivate: [UserGuardGuard, AdmitGuard]},
  { path: "PerfilU", component: PerfilComponent},
  { path: "Cargando_Administrador", component: CargarAdmitComponent, canActivate: [UserGuardGuard, AdmitGuard] }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

export const routesComponent = [
  LoginComponent,
  PrincipalComponent,
  AgregarPostComponent,
  AdministradorComponent,
  OfertasComponent,
  NavegacionComponent,
  PerfilComponent,
  TrabajoDetallesComponent,
  PieComponent,
  CargarAdmitComponent
];