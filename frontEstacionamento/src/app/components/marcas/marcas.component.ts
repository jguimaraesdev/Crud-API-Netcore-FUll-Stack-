
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MarcasService } from 'src/app/marcas.service';
import { Marca } from 'src/app/Marca';
import { Observer } from 'rxjs';

@Component({
  selector: 'app-marcas',
  templateUrl: './marcas.component.html',
  styleUrls: ['./marcas.component.css'],
})

export class MarcasComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private marcasService: MarcasService) {}

  ngOnInit(): void {
    this.tituloFormulario = 'Nova Marca';
    this.formulario = new FormGroup({

      _idMarca: new FormControl(null),
      _nomeMarca: new FormControl(null),
      _segmento: new FormControl(null),

    });
  }
  enviarFormulario(): void {
    const marca: Marca = this.formulario.value;
    const observer: Observer<Marca> = {
      next(_result): void {
        alert('Marca salva com sucesso.');
      },
      error(_error): void {
        alert('Erro ao salvar!');
      },
      complete(): void {},
    };
    if (marca._idMarca && !isNaN(Number(marca._idMarca)))  {
      this.marcasService.alterar(marca).subscribe(observer);
    } else {
      this.marcasService.cadastrar(marca).subscribe(observer);
    }
  }
}