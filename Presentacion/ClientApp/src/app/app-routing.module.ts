import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { UserSessionComponent } from './user-session/user-session.component';
import { RegistrarEstudianteComponent } from './estudiante/registrar-estudiante/registrar-estudiante.component';
import { RegistrarHabitacionComponent } from './habitaciones/registrar-habitacion/registrar-habitacion.component';
import { ConsultarAsignadasComponent } from './habitaciones/consultar-asignadas/consultar-asignadas.component';
import { ConsultarDisponiblesComponent } from './habitaciones/consultar-disponibles/consultar-disponibles.component';
import { AsignarHabitacionComponent } from './habitaciones/asignar-habitacion/asignar-habitacion.component';

const routes: Routes = [
  {path: 'home',component: HomeComponent},
  {path: 'login',component: UserSessionComponent},
  {path: 'registrate',component: RegistrarEstudianteComponent },
  {path: 'registrar-habitaciones',component: RegistrarHabitacionComponent },
  {path: 'consultar-habitaciones-asignadas',component: ConsultarAsignadasComponent },
  {path: 'consultar-habitaciones-disponibles',component: ConsultarDisponiblesComponent },
  {path: 'asignar-habitacion',component: AsignarHabitacionComponent },
];

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes, { relativeLinkResolution: 'legacy' })
  ]
})
export class AppRoutingModule { }
