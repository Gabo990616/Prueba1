import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/model/User';
import { HabitacionService } from 'src/app/service/habitacion.service';

@Component({
  selector: 'app-consultar-asignadas',
  templateUrl: './consultar-asignadas.component.html',
  styleUrls: ['./consultar-asignadas.component.css']
})
export class ConsultarAsignadasComponent implements OnInit {
  usuarios:User[];
  constructor(private habitacionesService: HabitacionService) { }

  ngOnInit() {
    this.habitacionesService.getAsignadas().subscribe(x => {
      this.usuarios = x;
    })
  }

}
