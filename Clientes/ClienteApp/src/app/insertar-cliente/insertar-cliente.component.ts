// ----------------------------------------------------------------------
//  file="insertar-cliente.component.ts">
// ----------------------------------------------------------------------


import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Cliente } from '../models/cliente.model';
import { ClienteService } from '../services/cliente.service';

@Component({
  selector: 'app-insertar-cliente-component',
  templateUrl: './insertar-cliente.component.html',
  styleUrls: ['./insertar-cliente.component.scss']
})

export class InsertarClienteComponent implements OnInit {
  
  form: FormGroup;

  constructor(private formBuilder: FormBuilder, private clienteService: ClienteService){
    this.form = this.formBuilder.group(
      {
        id: 0,
        nombre: ['', [Validators.required]],
        tipoDocumento: ['', [Validators.required]],
        documento: ['', [Validators.required]],
        razonSocial: ['', [Validators.required]],
        proveedores: ['', [Validators.required]],
        ventasUltimo: ['', [Validators.required]],
      }
    )
  }

  ngOnInit(): void {
      
  }
  
  guardar(){

    const cliente: Cliente ={
      nombre: this.form.get('nombre')?.value,
      tipoDocumento: this.form.get('tipoDocumento')?.value,
      documento: this.form.get('documento')?.value,
      razonSocial: this.form.get('razonSocial')?.value,
      proveedores: this.form.get('proveedores')?.value,
      ventasUltimo: this.form.get('ventasUltimo')?.value,

    }
    
    this.clienteService.insertarCliente(cliente).subscribe(data => {
      console.log('Guardado existosamente');
      this.form.reset();
    })
  }

}
  