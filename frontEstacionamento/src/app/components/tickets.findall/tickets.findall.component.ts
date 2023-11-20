import { Component } from '@angular/core';
import { Periodo } from 'src/app/models/Periodo';
import { Ticket } from 'src/app/models/Ticket';
import { PeriodosService } from 'src/app/services/periodos.service';
import { TicketsService } from 'src/app/services/tickets.service';

@Component({
  selector: 'app-tickets.findall',
  templateUrl: './tickets.findall.component.html',
  styleUrls: ['./tickets.findall.component.css']
})
export class TicketsFindallComponent {


  formulario: any;
  tituloFormulario: string = '';

  listatickets: Array<Ticket> = new Array;
  listaticket: Array<Ticket> = new Array;
  listaperiodos: Array<Periodo> = new Array;
  lista:Array<Periodo> = new Array;

  constructor(private ticketservice : TicketsService, private periodoService: PeriodosService){}
  

  ngOnInit(): void{

    this.tituloFormulario = 'iniciar Pagamento';

    this.ticketservice.listar().subscribe(tickets => {
  
      console.log(tickets);
      this.listaticket = tickets;
      this.listatickets = tickets;
    });

    this.periodoService.listar().subscribe(periodos =>{
      this.listaperiodos = periodos;
    });


  }
 

  search(event: Event) {
    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase; // Transforma o valor para minúsculas
  
    this.listatickets = this.listatickets.filter(tickets=> {
      return tickets._idTicket === Number(value);
    })
  }
  
  
}


