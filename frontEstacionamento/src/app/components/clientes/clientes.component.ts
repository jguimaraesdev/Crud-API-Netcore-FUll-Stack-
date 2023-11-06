import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ClientesService } from 'src/app/clientes.service';
import { Cliente } from 'src/app/Cliente';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-clientes',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  
  constructor(private clientesService : ClientesService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Cliente';
    this.formulario = new FormGroup({
      _Cpf: new FormControl(null),
      _Nome: new FormControl(null),
      _Email: new FormControl(null)
    })
  }
  enviarFormulario(): void {
    const cliente: Cliente = this.formulario.value;
    const observer: Observer<Cliente> = {
      next(_result): void {
        alert('Cliente salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar!');
      },
      complete(): void {
      },
    };
    if (cliente._Cpf && !isNaN(Number(cliente._Cpf))) {
      this.clientesService.alterar(cliente).subscribe(observer);
    } else {
      this.clientesService.cadastrar(cliente).subscribe(observer);
    }
  }
}
