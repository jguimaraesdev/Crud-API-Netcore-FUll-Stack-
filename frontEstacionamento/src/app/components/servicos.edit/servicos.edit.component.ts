import { Component, EventEmitter, Input, Output } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { Observer } from 'rxjs';
import { Servico } from 'src/app/models/Servico';
import { Ticket } from 'src/app/models/Ticket';
import { ServicosService } from 'src/app/services/servicos.service';
import { TicketsService } from 'src/app/services/tickets.service';

@Component({
  selector: 'app-servicos.edit',
  templateUrl: './servicos.edit.component.html',
  styleUrls: ['./servicos.edit.component.css']
})
export class ServicosEditComponent {

  servicos!: Servico;//para receber dados do funcionario para editar
  
  tituloFormulario: string = '';
  servicosform!: FormGroup;
  router: any;

  constructor(private servicoService : ServicosService) { }


  ngOnInit(): void {
    

    this.tituloFormulario = 'Editar Serviço';

    this.servicosform = new FormGroup({
      _idServico: new FormControl(null),
      _codTicket: new FormControl(null),
      _valorServico: new FormControl(null),
      _tipoServico: new FormControl(null),
      _Pagamento: new FormControl(null),
    });
  }

 

  enviarFormulario(): void {

    const servico: Servico = this.servicosform.value;
    console.log(servico);
  
    const observer: Observer<Servico> = {
      next: (_result): void => {
        alert('Serviço alterado com sucesso.');

      },
      error: (_error): void => {
        alert('Erro ao salvar!');
      },
      complete: (): void => {
        // Ação a ser executada ao completar
      },
    };
  
    this.servicoService.alterar(servico).subscribe(observer);
    setTimeout(()=> this.router.navigate(["/pagar"]), 3000)
    
    
  }    
  
}  


