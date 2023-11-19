import { Component } from '@angular/core';
import { Servico } from 'src/app/models/Servico';
import { Ticket } from 'src/app/models/Ticket';
import { ServicosService } from 'src/app/services/servicos.service';

@Component({
  selector: 'app-pagar',
  templateUrl: './pagar.component.html',
  styleUrls: ['./pagar.component.css']
})
export class PagarComponent {

  formulario: any;
  tituloFormulario: string = '';

  listaservicos: Array<Servico> = new Array;
  listaservico: Array<Servico> = new Array;

  constructor(private servicoService : ServicosService){}

  ngOnInit(): void{

    this.tituloFormulario = 'iniciar Pagamento';

    this.servicoService.listar().subscribe(servicos => {
  
      console.log(servicos);
      this.listaservicos = servicos;
      this.listaservico = servicos;

      /*
      if (this.listaservicos && this.listaservicos.length > 0) {
        this.formulario.get('_idServico')?.setValue(this.listaservicos[0]._idServico);
      }*/
    });

  }


}
