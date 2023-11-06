
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Observer } from 'rxjs';
import { ModelosService } from 'src/app/modelos.service';
import { Modelo } from 'src/app/Modelo';
import { Marca } from 'src/app/Marca';
import { MarcasService } from 'src/app/marcas.service';

@Component({
  selector: 'app-modelos',
  templateUrl: './modelos.component.html',
  styleUrls: ['./modelos.component.css']
})
export class ModelosComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';
  marcas: Array<Marca> | undefined;

  constructor(private modelosService : ModelosService, private marcasService: MarcasService) { }

  ngOnInit(): void {
    
    this.tituloFormulario = 'Novo Modelo';

    this.marcasService.listar().subscribe(marcas => {
      this.marcas = marcas;
      if (this.marcas && this.marcas.length > 0) {
        this.formulario.get('_idMarca')?.setValue(this.marcas[0]._idMarca);
      }
    });
    
    this.formulario = new FormGroup({
      _idModelo: new FormControl(null),
      _nomeModelo: new FormControl(null),
      _motor: new FormControl(null),
      _qtdPortas: new FormControl(null),
      _AnoModelo: new FormControl(null),
      _TipoModelo: new FormControl(null),
      _idMarca: new FormControl(null)

    })
  }
  enviarFormulario(): void {
    const modelo: Modelo = this.formulario.value;
    const observer: Observer<Modelo> = {
      next(_result): void {
        alert('Modelo salvo com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar!');
      },
      complete(): void {
      },
    };
    if (modelo._idModelo && !isNaN(Number(modelo._idModelo))) {
      this.modelosService.alterar(modelo).subscribe(observer);
    } else {
      this.modelosService.cadastrar(modelo).subscribe(observer);
    }
  }
}