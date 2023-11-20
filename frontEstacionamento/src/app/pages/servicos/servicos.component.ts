import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observer } from 'rxjs';
import { Servico } from 'src/app/models/Servico';
import { Ticket } from 'src/app/models/Ticket';
import { ServicosService } from 'src/app/services/servicos.service';
import { TicketsService } from 'src/app/services/tickets.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-servico',
  templateUrl: './servicos.component.html',
  styleUrls: ['./servicos.component.css']
})
export class ServicosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  
  tickets: Array<Ticket> = new Array;
  listaservicos: Array<Servico> = new Array;


  constructor(private servicoService : ServicosService,  
    private ticketsService: TicketsService,
    private router: Router) { }


  ngOnInit(): void {
    
    this.tituloFormulario = 'Novo Servico';

    this.ticketsService.listar().subscribe(ticket => {
      this.tickets = ticket;

      if (this.tickets && this.tickets.length > 0) {
        this.formulario.get('_codTicket')?.setValue(this.tickets[0]._codTicket);
      }
    });

    
    this.formulario = new FormGroup({
      _idServico: new FormControl(null),
      _codTicket: new FormControl(null,[Validators.required]),
      _valorServico: new FormControl(null, [Validators.required]),
      _tipoServico: new FormControl(null, [Validators.required]),
      _Pagamento: new FormControl(false),
    });
  }

 



  enviarFormulario(): void {
    const servico: Servico = this.formulario.value;
    console.log(servico);
  
    const observer: Observer<Servico> = {
      next: (_result): void => {
        alert('Serviço salvo com sucesso.');

      },
      error: (_error): void => {
        alert('Erro ao salvar!');
      },
      complete: (): void => {
        // Ação a ser executada ao completar
      },
    };
    
    if (servico._idServico && !isNaN(Number(servico._idServico))) {
      this.servicoService.alterar(servico).subscribe(observer);
      setTimeout(()=> this.router.navigate(["/home"]), 3000)
    } else {
      this.servicoService.cadastrar(servico).subscribe(observer);
      setTimeout(()=> this.router.navigate(["/home"]), 3000)
    }
  }

  
  
    
  
}  
