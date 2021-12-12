import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, catchError } from 'rxjs/operators'
import { Asignar, Habitacion } from '../model/Habitacions';
import { User } from '../model/User';
import { HandleHttpErrorService } from './handle-http-error.service';
@Injectable({
  providedIn: 'root'
})
export class HabitacionService {

  baseUrl: string;
  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') baseUrl: string,
    private handleErrorService: HandleHttpErrorService
 ) 
 {
    this.baseUrl = baseUrl; 
  }
  
  get(): Observable<Habitacion[]> {
    return this.http.get<Habitacion[]>(this.baseUrl + 'api/Habitacion').pipe(
      tap(_ => this.handleErrorService.log('mostrados correctamentes')),
      catchError(this.handleErrorService.handleError<Habitacion[]>('consultar empleado', null))
      );
  }

  getAsignadas(): Observable<User[]> {
    return this.http.get<User[]>(this.baseUrl + 'api/Habitacion/asignadas').pipe(
      tap(_ => this.handleErrorService.log('mostrados correctamentes')),
      catchError(this.handleErrorService.handleError<User[]>('consultar empleado', null))
      );
  }

  getDisponibles(): Observable<Habitacion[]> {
    return this.http.get<Habitacion[]>(this.baseUrl + 'api/Habitacion/disponibles').pipe(
      tap(_ => this.handleErrorService.log('mostrados correctamentes')),
      catchError(this.handleErrorService.handleError<Habitacion[]>('consultar empleado', null))
      );
  }

  post(habitacion: Habitacion): Observable<Habitacion> {
    return this.http.post<Habitacion>(this.baseUrl + 'api/Habitacion', habitacion).pipe(
      tap(_ => this.handleErrorService.log('datos enviados correctamentes')),
      catchError(this.handleErrorService.handleError<Habitacion>('registrar empleado', null))
      );
  }

  postAsignar(Asignar: Asignar): Observable<User> {
    return this.http.post<User>(this.baseUrl + 'api/Habitacion/asignar', Asignar).pipe(
      tap(_ => this.handleErrorService.log('datos enviados correctamentes')),
      catchError(this.handleErrorService.handleError<User>('registrar empleado', null))
      );
  }
}
