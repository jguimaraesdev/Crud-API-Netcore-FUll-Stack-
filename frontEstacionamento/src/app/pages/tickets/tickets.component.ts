import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observer, timeout } from 'rxjs';
import { Ticket } from 'src/app/models/Ticket';
import { Veiculo } from 'src/app/models/Veiculo';
import { TicketsService } from 'src/app/services/tickets.service';
import { v4 as uuidv4 } from 'uuid';//instalar com 'npm i --save-dev @types/uuid'
import { Router } from '@angular/router';


@Component({
  selector: 'app-ticket',
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.css']
})
export class TicketsComponent implements OnInit {
  formulario: any;
  formulario1: any;
  tituloFormulario: string = '';


  veiculos: Array<Veiculo> | undefined;
  
  constructor(
    private ticketsService : TicketsService, 
    private router: Router) { }



  //--------------------------------------------------------------------------------------//

  ngOnInit(): void {
    
    this.tituloFormulario = 'Novo Entrada / Ticket';
    
    this.formulario = new FormGroup({
      _idTicket: new FormControl(null),
      _codTicket: new FormControl(uuidv4()),// Use uuidv4() para gerar um identificador único
      _Placa: new FormControl(null, [Validators.required]),
      _HoraEntrada: new FormControl(new Date()),
      _HoraSaida: new FormControl(null),
      _Pagamento: new FormControl(false),
      

    });

  }

  
  //--------------------------------------------------------------------------------------//

  enviarFormulario(): void {

    const ticket: Ticket = this.formulario.value;
    console.log(ticket);
    const observer: Observer<Ticket> = {
      next(_result): void {
        alert('Ticket salvo com sucesso.');
        alert('Periodo Iniciado.');
      },
      error(_error): void {
        alert('Erro ao salvar!');
      },
      complete(): void {
      },
    };
    if (this.formulario.value._idTicket && !isNaN(Number(this.formulario.value._idTicket))) {
        this.ticketsService.alterar(this.formulario.value).subscribe(observer);
  
      setTimeout(()=> this.router.navigate(["/home"]), 3000);
      
      
    } else {
      this.ticketsService.cadastrar(this.formulario.value).subscribe(observer);
      
      setTimeout(()=> this.router.navigate(["/home"]), 3000);
    }

    
  }

  
  //--------------------------------------------------------------------------------------//
}