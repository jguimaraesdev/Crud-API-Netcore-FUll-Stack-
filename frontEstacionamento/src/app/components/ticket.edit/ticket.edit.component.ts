import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Observer } from 'rxjs';
import { Ticket } from 'src/app/models/Ticket';
import { TicketsService } from 'src/app/services/tickets.service';

@Component({
  selector: 'app-ticket.edit',
  templateUrl: './ticket.edit.component.html',
  styleUrls: ['./ticket.edit.component.css']
})
export class TicketEditComponent {

  formulario: any;
  tituloFormulario: string = '';
  
  ticketlist: Array<Ticket> | undefined;


  constructor(private ticketService: TicketsService, private router: Router) { }


  ngOnInit(): void {
    
    this.tituloFormulario = 'Editar Ticket';

    this.ticketService.listar().subscribe(cliente => {
      this.ticketlist = cliente;
    });
    
    
    
    this.formulario = new FormGroup({
    _idTicket: new FormControl(null),
    _Placa:new FormControl(null),
    _HoraSaida: new FormControl(new Date()),
    _Pagamento: new FormControl(true),
    });

  }

  enviarFormulario(): void {
    const ticket: Ticket = this.formulario.value;
    const observer: Observer<Ticket> = {
      next(_result): void {
        alert('Ticket editado com sucesso.');
        
      },
      error(_error): void {
        alert('Erro ao pagar!');
      },
      complete(): void {
      },
    };
    
      this.ticketService.alterar(ticket).subscribe(observer);
      setTimeout(()=> this.router.navigate(["/ticketsfindall"]), 3000);
  }

}

