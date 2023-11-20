import { Component, Input } from '@angular/core';
import { Observer } from 'rxjs';
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
    });

  }
 

  search(event: Event) {
    const target = event.target as HTMLInputElement;
    const value = target.value.toLowerCase; // Transforma o valor para minúsculas
  
    this.listaservico = this.listaservicos.filter(servicos => {
      return servicos._idServico === Number(value);
    });
  }
  

  excluirRegistro(id?: number): void {
    
      if (id !== undefined) {
        // Lógica de exclusão aqui...
        this.servicoService.excluir(id).subscribe({
          next: () => {
            alert('Registro excluído com sucesso.');
            // Lógica adicional após a exclusão, se necessário
          },
          error: (error) => {
            console.error('Erro ao excluir:', error);
            alert('Erro ao excluir o registro.');
          },
          complete: () => {
            // Lógica adicional após a conclusão da exclusão, se necessário
          },
        });
      } else {
        // Lidar com a situação em que 'id' é undefined
        console.error('ID não fornecido para excluirRegistro');
      }
    }
    
  }

