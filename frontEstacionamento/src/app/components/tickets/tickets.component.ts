import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { Periodo } from 'src/app/models/Periodo';
import { PeriodosService } from 'src/app/services/periodos.service';
import { Ticket } from 'src/app/models/Ticket';
import { Veiculo } from 'src/app/models/Veiculo';
import { TicketsService } from 'src/app/services/tickets.service';
import { VeiculosService } from 'src/app/services/veiculos.service';

@Component({
  selector: 'app-ticket',
  templateUrl: './tickets.component.html',
  styleUrls: ['./tickets.component.css']
})
export class TicketsComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  veiculos: Array<Veiculo> | undefined;
  periodos: Array<Periodo> | undefined;


  constructor(private ticketsService : TicketsService, 
    private veiculosService: VeiculosService, 
    private periodosService: PeriodosService) { }


  ngOnInit(): void {
    
    this.tituloFormulario = 'Novo Ticket';

    this.veiculosService.listar().subscribe(veiculo => {
      this.veiculos = veiculo;
      if (this.veiculos && this.veiculos.length > 0) {
        this.formulario.get('_Placa')?.setValue(this.veiculos[0]._Placa);
      }
    });

    this.periodosService.listar().subscribe(periodo => {
      this.periodos = periodo;
      if(this.periodos && this.periodos.length > 0){
        this.formulario.get('_idPeriodo')?.setValue(this.periodos[0]._idPeriodo);
        
      }
    });
    
    this.formulario = new FormGroup({
      _codTicket: new FormControl(null),
      _Placa: new FormControl(null),
      _idPeriodo: new FormControl(null)
      

    })
  }
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
    /*if (ticket._codTicket && !isNaN(Number(ticket._codTicket))) {
      this.ticketsService.alterar(ticket).subscribe(observer);
    } else {*/
      this.ticketsService.cadastrar(ticket).subscribe(observer);
    }
  
}