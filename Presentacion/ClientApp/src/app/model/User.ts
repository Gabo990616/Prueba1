import { Habitacion } from "./Habitacions";

export class User {
    identificacion:string;
    nombre:string;
    user:string;
    password:string;
    rol:string;
    token:string;
    habitacion:Habitacion;
}

export class Login{
    user:String;
    password:string;
}