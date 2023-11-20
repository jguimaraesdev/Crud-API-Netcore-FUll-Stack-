import { Component } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Observer } from 'rxjs';
import { Ticket } from 'src/app/models/Ticket';
import { TicketsService } from 'src/app/services/tickets.service';

@Component({
  selector: 'app-pagar.ticket',
  templateUrl: './pagar.ticket.component.html',
  styleUrls: ['./pagar.ticket.component.css']
})
export class PagarTicketComponent {


  formulario: any;
  tituloFormulario: string = '';
  
  ticketlist: Array<Ticket> | undefined;


  constructor(private ticketService: TicketsService) { }


  ngOnInit(): void {
    
    this.tituloFormulario = 'Pagar Ticket';

    this.ticketService.listar().subscribe(cliente => {
      this.ticketlist = cliente;
    });
    
    
    
    this.formulario = new FormGroup({
    _idTicket: new FormControl(null),
    _codTicket: new FormControl(null),
    _HoraSaida: new FormControl(new Date()),
    _Pagamento: new FormControl(true),
    });

  }

  enviarFormulario(): void {
    const ticket: Ticket = this.formulario.value;
    const observer: Observer<Ticket> = {
      next(_result): void {
        alert('Ticket pago com sucesso.');
      },
      error(_error): void {
        alert('Erro ao pagar!');
      },
      complete(): void {
      },
    };
    
      this.ticketService.alterar(ticket).subscribe(observer);
  }

}