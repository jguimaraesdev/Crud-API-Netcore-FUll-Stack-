
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Observer } from 'rxjs';
import { Veiculo } from 'src/app/models/Veiculo';
import { VeiculosService } from 'src/app/services/veiculos.service';
import { Periodo } from 'src/app/models/Periodo';
import { PeriodosService } from 'src/app/services/periodos.service';
import { getLocaleDateTimeFormat } from '@angular/common';

@Component({
  selector: 'app-periodo',
  templateUrl: './periodos.component.html',
  styleUrls: ['./periodos.component.css']
})
export class PeriodosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  veiculos: Array<Veiculo> | undefined;

  constructor(private periodosService : PeriodosService, private veiculosService: VeiculosService) { }

  ngOnInit(): void {
    
    this.tituloFormulario = 'Registrar';

    this.veiculosService.listar().subscribe(veiculos => {
      this.veiculos = veiculos;
      if (this.veiculos && this.veiculos.length > 0) {
        this.formulario.get('_Placa')?.setValue(this.veiculos[0]._Placa);
      }
    });
    
    this.formulario = new FormGroup({
      _idPeriodo: new FormControl(null),
      _HoraEntrada: new FormControl( new Date()),
      _HoraSaida: new FormControl(null,[Validators.required]),
      _Placa: new FormControl(null, [Validators.required])

    })
  }
  enviarFormulario(): void {
    const periodo: Periodo = this.formulario.value;
    const observer: Observer<Periodo> = {
      next(_result): void {
        alert('Salvo com sucesso.');
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
}