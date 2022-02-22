// ----------------------------------------------------------------------
//  file="cliente.component.ts">
// ----------------------------------------------------------------------


import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Cliente } from '../models/cliente.model';

@Component({
  selector: 'app-cliente-component',
  templateUrl: './cliente.component.html'
})

export class ClienteComponent {
    
  public clientes: string[] = [];


  constructor(http: HttpClient, @Inject("BASE_URL") baseUrl: string) {
      
  }
}
  