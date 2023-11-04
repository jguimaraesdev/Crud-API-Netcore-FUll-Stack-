import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { VeiculosService } from 'src/app/veiculos.service';
import { Veiculo } from '../../Veiculo';

@Component({
  selector: 'app-veiculo',
  templateUrl: './veiculos.component.html',
  styleUrls: ['./veiculos.component.css']
})

export class VeiculosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  
  constructor(private veiculosService : VeiculosService) { }

  ngOnInit(): void {
    this.tituloFormulario = 'Novo Veiculo';
    this.formulario = new FormGroup({
      
      _idVeiculo: new FormControl(null),
      _Placa: new FormControl(null),
      _Descricao: new FormControl(null)

    })
  }
  enviarFormulario(): void {
    const veiculo : Veiculo= this.formulario.value;
    this.veiculosService.cadastrar(veiculo).subscribe(result => {
      alert('Veiculo inserido com sucesso.');
    })
  } 
}