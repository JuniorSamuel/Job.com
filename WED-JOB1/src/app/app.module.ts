import { ApiService } from 'src/app/servicios/Api/api.service';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatRadioModule, MAT_RADIO_DEFAULT_OPTIONS } from '@angular/material/radio';
import { MatTableModule } from '@angular/material/table'
import { MatInputModule} from '@angular/material/input';

import { AppRoutingModule, routesComponent } from './app-routing.module';
import { AppComponent } from './app.component';
import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


import { MatPaginatorModule } from '@angular/material/paginator';
import { UsuarioComponent } from './vista/administrador/pestañas/usuario/usuario.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PosterComponent } from './vista/administrador/pestañas/poster/poster.component';
import { CategoriaComponent } from './vista/administrador/pestañas/categoria/categoria.component';
import { PostComponent } from './vista/administrador/pestañas/post/post.component';
import { ConfigComponent } from './vista/administrador/pestañas/config/config.component';
import { AdmitComponent } from './vista/administrador/pestañas/admit/admit.component';
import { PieComponent } from './compomente/pie/pie.component';
import { NavegacionComponent } from './compomente/navegacion/navegacion.component';
import { ModalpruebaComponent } from './vista/administrador/pestañas/usuario/modalprueba/modalprueba.component';
import { OfertasComponent } from './vista/ofertas/ofertas.component';

import {MatDialogModule} from '@angular/material/dialog';//PARA PRUEBA
import { AgregarPostComponent } from './vista/agregar-post/agregar-post.component';
import { AgregarAdministradorComponent } from './vista/agregar-administrador/agregar-administrador.component';
import { AgregarCategoriaComponent } from './vista/agregar-categoria/agregar-categoria.component';
import { CargarComponent } from './vista/cargar/cargar.component';//PARA PRUEBA

import {MatFormFieldModule} from '@angular/material/form-field';
import { RegistrarComponent } from './vista/registrar/registrar.component';
import { MisPostComponent } from './vista/mis-post/mis-post.component';
import { JwtInteceptorInterceptor } from './servicios/intercepto/jwt-inteceptor.interceptor';
import { FiltroTablaPipe } from './pipe/filtro-tabla.pipe';
import { CargarAdmitComponent } from './vista/cargar-admit/cargar-admit.component';

@NgModule({
  declarations: [
    AppComponent,
    routesComponent,
    UsuarioComponent,
    PosterComponent,
    CategoriaComponent,
    PostComponent,
    ConfigComponent,
    AdmitComponent,
    PieComponent,
    NavegacionComponent,
    ModalpruebaComponent,
    // MatDialogModule,
    OfertasComponent,
    AgregarAdministradorComponent,
    AgregarCategoriaComponent,
    RegistrarComponent,
    CargarComponent,
    // CargarComponent,
    MisPostComponent,  
    FiltroTablaPipe, CargarAdmitComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    MatRadioModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatPaginatorModule,
    MatInputModule, 
    MatDialogModule,
    MatFormFieldModule,//validaciones
  ],

  providers: [
    routesComponent,
    ApiService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInteceptorInterceptor,
      multi: true
    },
    {
      provide: MAT_RADIO_DEFAULT_OPTIONS,
      useValue: { color: 'primary' },
    }
  ],
  bootstrap: [AppComponent],

  entryComponents:[AgregarCategoriaComponent, AgregarPostComponent] //PARA ABRIR DIALOG

})
export class AppModule { }
