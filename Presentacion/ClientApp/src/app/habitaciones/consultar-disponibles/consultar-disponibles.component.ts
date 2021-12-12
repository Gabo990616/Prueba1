import { Component, OnInit } from '@angular/core';
import { Habitacion } from 'src/app/model/Habitacions';
import { HabitacionService } from 'src/app/service/habitacion.service';

@Component({
  selector: 'app-consultar-disponibles',
  templateUrl: './consultar-disponibles.component.html',
  styleUrls: ['./consultar-disponibles.component.css']
})
export class ConsultarDisponiblesComponent implements OnInit {
  habitaciones:Habitacion[];
  constructor(private habitacionesService:HabitacionService) { }

  ngOnInit() {
    this.habitacionesService.getDisponibles().subscribe(x=> {
      this.habitaciones =x;
    })
  }

}
