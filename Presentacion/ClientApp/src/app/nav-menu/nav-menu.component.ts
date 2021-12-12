import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { User } from '../model/User';
import { AuthenticationService } from '../service/authentication.service';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;
  usuario:User;
  constructor(private autenticacion:AuthenticationService,  private router: Router){
    this.autenticacion.currentUser.subscribe(x => this. usuario= x);
  }
  
  ngOnInit() {
     
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }
  cerrarSesion()
  {
    this.autenticacion.logout();
    this.router.navigate(['home']);
  }
}
