import { Injectable } from "@angular/core";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { Observable, of } from "rxjs";

@Injectable({
  providedIn: "root",
})
export class HandleHttpErrorService {
  constructor() {}
  public handleError<T>(operation = "operation", result?: T) {
    return (error: any): Observable<T> => {
      if (error.status == "500") {
        this.mostrarError500(error);
      }
      if (error.status == "400") {
        this.mostrarError400(error);
      }
      return of(result as T);
    };
  }

  mostrarError400(error: any) {
    
    
  }

  mostrarError500(error: any) {
    console.log(error);
  }

  public log(message: string) {
    console.log(message);
  }
}
