import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Cliente } from 'src/app/models/Cliente';
import { ClientesService } from 'src/app/services/clientes.service';
import { Servico } from 'src/app/models/Servico';
import { ServicosService } from 'src/app/services/servicos.service';
import { NotaFiscalService } from 'src/app/services/notas-fiscais.service';
import { NotaFiscal } from 'src/app/models/NotaFiscal';

@Component({
  selector: 'app-modelos',
  templateUrl: './notas-fiscais.component.html',
  styleUrls: ['./notas-fiscais.component.css']
})
export class NotasFiscaisComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  clientes: Array<Cliente> | undefined;
  servicos: Array<Servico> | undefined;


  constructor(private notaFiscalService : NotaFiscalService, 
    private clientesService: ClientesService, 
    private servicosService: ServicosService) { }


  ngOnInit(): void {
    
    this.tituloFormulario = 'Nota Fiscal';

    this.clientesService.listar().subscribe(cliente => {
      this.clientes = cliente;
      if (this.clientes && this.clientes.length > 0) {
        this.formulario.get('_Cpf')?.setValue(this.clientes[0]._Cpf);
      }
    });

    this.servicosService.listar().subscribe(servico => {
      this.servicos = servico;
      if(this.servicos && this.servicos.length > 0){
        this.formulario.get('_idServico')?.setValue(this.servicos[0]._idServico);
      }
    });
    
    this.formulario = new FormGroup({
      _NumeroNota:  new FormControl(null),
      _ValorDaNota: new FormControl(null),
      _Cpf: new FormControl(null),
      _idServico: new FormControl(null),

    })
  }
  enviarFormulario(): void {
    const notas: NotaFiscal = this.formulario.value;
    const observer: Observer<NotaFiscal> = {
      next(_result): void {
        alert('Nota Fiscal salva com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar!');
      },
      complete(): void {
      },
    };
    if (notas._NumeroNota && !isNaN(Number(notas._NumeroNota))) {
      this.notaFiscalService.alterar(notas).subscribe(observer);
    } else {
      this.notaFiscalService.cadastrar(notas).subscribe(observer);
    }
  }
}