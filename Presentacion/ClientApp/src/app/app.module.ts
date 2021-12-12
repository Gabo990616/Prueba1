import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { AppRoutingModule } from './app-routing.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { JwtInterceptor } from './service/Jwt.Interceptor';
import { UserSessionComponent } from './user-session/user-session.component';
import { RegistrarEstudianteComponent } from './estudiante/registrar-estudiante/registrar-estudiante.component';
import { UsuarioService } from './service/usuario.service';
import { RegistrarHabitacionComponent } from './habitaciones/registrar-habitacion/registrar-habitacion.component';
import { ConsultarAsignadasComponent } from './habitaciones/consultar-asignadas/consultar-asignadas.component';
import { ConsultarDisponiblesComponent } from './habitaciones/consultar-disponibles/consultar-disponibles.component';
import { AsignarHabitacionComponent } from './habitaciones/asignar-habitacion/asignar-habitacion.component';


@NgModule({
  declarations: [		
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    UserSessionComponent, 
    RegistrarEstudianteComponent,
    RegistrarHabitacionComponent,
    ConsultarAsignadasComponent,
    ConsultarDisponiblesComponent,
    AsignarHabitacionComponent,
   ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    NgbModule,
    RouterModule.forRoot(
      [{ path: "", component: HomeComponent, pathMatch: "full" }],
      { relativeLinkResolution: "legacy" }
    ),
    AppRoutingModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
