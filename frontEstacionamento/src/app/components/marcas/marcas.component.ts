
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { MarcasService } from 'src/app/services/marcas.service';
import { Marca } from 'src/app/models/Marca';
import { Observer } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-marca',
  templateUrl: './marcas.component.html',
  styleUrls: ['./marcas.component.css'],
})

export class MarcasComponent implements OnInit {
  formulario: any;
  tituloFormulario: string = '';

  constructor(private marcasService: MarcasService, private router: Router) {}



  ngOnInit(): void {
    this.tituloFormulario = 'Nova Marca';
    this.formulario = new FormGroup({

      _idMarca: new FormControl(null),
      _nomeMarca: new FormControl(null),
      _segmento: new FormControl(null),

    });
  }


  navigateParaModelo(): void {
    this.router.navigate(['/modelo']);
  }



  enviarFormulario(): void {
    const marca: Marca = this.formulario.value;
    console.log(marca);

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
      setTimeout(()=> this.router.navigate(["/modelo"]), 3000)
    } else {
      this.marcasService.cadastrar(marca).subscribe(observer);
      setTimeout(()=> this.router.navigate(["/modelo"]), 3000)
    }
    

  }
  
}