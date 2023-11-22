import { Component } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Observer } from 'rxjs';
import { Servico } from 'src/app/models/Servico';
import { ServicosService } from 'src/app/services/servicos.service';

@Component({
  selector: 'app-servicos.pagar',
  templateUrl: './servicos.pagar.component.html',
  styleUrls: ['./servicos.pagar.component.css']
})
export class ServicosPagarComponent {

 listaservicos: Array<Servico> = new Array();
  
  tituloFormulario: string = '';
  servicosform!: FormGroup;
  

  constructor(private servicoService : ServicosService, private router: Router) { }


  ngOnInit(): void {
    
    this.servicoService.listar().subscribe(servicos =>{
      this.listaservicos = servicos;
    });

    this.tituloFormulario = 'Pagar Serviço';

    this.servicosform = new FormGroup({
      _idServico: new FormControl(null),
      _Pagamento: new FormControl(null),
    });
  }

 

  enviarFormulario(): void {

    const servico: Servico = this.servicosform.value;
    console.log(servico);
  
    const observer: Observer<Servico> = {
      next: (_result): void => {
        alert('Serviço alterado com sucesso.');
        setTimeout(()=> this.router.navigate(["/servicofindall"]), 3000);
      },
      error: (_error): void => {
        alert('Erro ao salvar!');
      },
      complete: (): void => {
        // Ação a ser executada ao completar
      },
    };
  
    this.servicoService.pagar(servico).subscribe(observer);
    

  }    

}  

