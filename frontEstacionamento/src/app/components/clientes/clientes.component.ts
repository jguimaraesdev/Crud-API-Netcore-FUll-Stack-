import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ClientesService } from 'src/app/services/clientes.service';
import { Cliente } from 'src/app/models/Cliente';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';


@Component({
  selector: 'app-cliente',
  templateUrl: './clientes.component.html',
  styleUrls: ['./clientes.component.css']
})
export class ClientesComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  
  constructor(private clientesService : ClientesService, private router: Router) { }

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
    console.log(cliente);
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
    /*
    if (cliente._Cpf && !isNaN(Number(cliente._Cpf))) {
      this.clientesService.alterar(cliente).subscribe(observer);

      setTimeout(()=> this.router.navigate(["/notafiscal"]), 3000);

    } else {*/
      this.clientesService.cadastrar(cliente).subscribe(observer);
      
      setTimeout(()=> this.router.navigate(["/notafiscal"]), 3000);
  }
}

