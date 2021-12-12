import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/model/User';
import { UsuarioService } from 'src/app/service/usuario.service';

@Component({
  selector: 'app-registrar-estudiante',
  templateUrl: './registrar-estudiante.component.html',
  styleUrls: ['./registrar-estudiante.component.css']
})
export class RegistrarEstudianteComponent implements OnInit {
  usuario:User;
  constructor(private userService: UsuarioService) { 
    this.usuario = new User();
  }

  ngOnInit() {
  
  }

  guarda() {
   this.userService.post(this.usuario).subscribe(x => {
    if (x != null) {
      alert("Guardado exitoso");
    }
   })
  }

}
