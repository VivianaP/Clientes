import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { Cliente } from "../models/cliente.model";

@Injectable()
export class ClienteService {

    myApiUrl = 'api/Cliente/';

    constructor( private http: HttpClient ) {
    }

    insertarCliente(cliente: Cliente): Observable<Cliente>{
        return this.http.post<Cliente>(this.myApiUrl, cliente);
    }
}


