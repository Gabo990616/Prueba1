import { Component, OnInit } from '@angular/core';
import { Habitacion } from 'src/app/model/Habitacions';
import { HabitacionService } from 'src/app/service/habitacion.service';

@Component({
  selector: 'app-registrar-habitacion',
  templateUrl: './registrar-habitacion.component.html',
  styleUrls: ['./registrar-habitacion.component.css']
})
export class RegistrarHabitacionComponent implements OnInit {
  habitacion:Habitacion;
  constructor(private habitacionService:HabitacionService) {
    this.habitacion = new Habitacion();
   }

  ngOnInit() {
  }

  guardarHabitacion(){
    this.habitacionService.post(this.habitacion).subscribe(x => {
      if (x!=null) {
        alert("Guardado exitoso")
      }
    })
  }

}
