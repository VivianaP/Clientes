import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Cliente } from '../models/cliente.model';

@Injectable({
  providedIn: 'root'
})
export class ClienteService {
  myAppUrl = 'https://localhost:44458/'
  myApiUrl = 'api/Cliente';

  constructor(private http: HttpClient) { }

  insertarCliente (cliente: Cliente): Observable<Cliente>{
    return this.http.post<Cliente>(this.myAppUrl  + this.myApiUrl, cliente)
  }

}
