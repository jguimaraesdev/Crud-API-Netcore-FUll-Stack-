import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer, timeout } from 'rxjs';
import { Periodo } from 'src/app/models/Periodo';
import { PeriodosService } from 'src/app/services/periodos.service';
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
  periodos: Array<Periodo> | undefined;


  constructor(
    private ticketsService : TicketsService, 
    private periodosService: PeriodosService,
    private router: Router) { }



  //--------------------------------------------------------------------------------------//

  ngOnInit(): void {
    
    this.tituloFormulario = 'Novo Entrada / Ticket';
    
    this.formulario = new FormGroup({
      _idTicket: new FormControl(null),
      _codTicket: new FormControl(uuidv4()),// Use uuidv4() para gerar um identificador único
      _Placa: new FormControl(null),
      _idPeriodo: new FormControl(null)
      

    });

    this.periodosService.listar().subscribe(periodo => {
      this.periodos = periodo;
      if(this.periodos && this.periodos.length > 0){
        this.formulario.get('_idPeriodo')?.setValue(this.periodos[0]._idPeriodo);
        
      }
    });
  }

  
  //--------------------------------------------------------------------------------------//

  enviarFormulario(): void {

    const ticket: Ticket = this.formulario.value;
    console.log(ticket);
    const observer: Observer<Ticket> = {
      next(_result): void {
        alert('Ticket salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar!');
      },
      complete(): void {
      },
    };
    if (this.formulario.value._idTicket && !isNaN(Number(this.formulario.value._idTicket))) {
      this.ticketsService.alterar(this.formulario.value).subscribe(observer);
      this.startPeriodo(this.formulario.value._Placa);
      
      setTimeout(()=> this.router.navigate(["/home"]), 3000)
      
      
    } else {
      this.ticketsService.cadastrar(this.formulario.value).subscribe(observer);
      this.startPeriodo(this.formulario.value._Placa);
      setTimeout(()=> this.router.navigate(["/home"]), 3000)
    }

    
  }


  //--------------------------------------------------------------------------------------//

  startPeriodo(placa: string) : void{

    this.formulario1 = new FormGroup({
      _idPeriodo: new FormControl(null),
      _HoraEntrada: new FormControl(null),
      _HoraSaida: new FormControl(null),
      _Placa: new FormControl(placa)

    });

    const periodo: Periodo = this.formulario1.value;
    console.log(periodo);
    const observer: Observer<Periodo> = {
      next(_result): void {
        alert('Periodo iniciado.');

      },
      error(_error): void {
        alert('Erro ao salvar!');
      },
      complete(): void {
      },

    };
    if (periodo._idPeriodo && !isNaN(Number(periodo._idPeriodo))) {
      this.periodosService.alterar(periodo).subscribe(observer);
      
    } else {
      this.periodosService.cadastrar(periodo).subscribe(observer);
      
    }

    
  }
  
  
  //--------------------------------------------------------------------------------------//
}