import { Component, OnInit } from '@angular/core';
import { Asignar, Habitacion } from 'src/app/model/Habitacions';
import { HabitacionService } from 'src/app/service/habitacion.service';

@Component({
  selector: 'app-asignar-habitacion',
  templateUrl: './asignar-habitacion.component.html',
  styleUrls: ['./asignar-habitacion.component.css']
})
export class AsignarHabitacionComponent implements OnInit {
   asignarHabitacion:Asignar;
   habitaciones:Habitacion[];
  constructor(private habicacionService:HabitacionService) {
    this.asignarHabitacion = new Asignar();
   }

  ngOnInit() {
    this.habicacionService.getDisponibles().subscribe(x=> {
      this.habitaciones =x;
    })
  }

  asignar(){
    
    this.habicacionService.postAsignar(this.asignarHabitacion).subscribe(asignar => {
        if (asignar!=null) {
          alert("Registro existoso")
        }
    })
  }
}
