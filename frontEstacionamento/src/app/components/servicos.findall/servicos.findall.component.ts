import { Component} from '@angular/core';
import { Servico } from 'src/app/models/Servico';
import { ServicosService } from 'src/app/services/servicos.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-servicos.findall',
  templateUrl: './servicos.findall.component.html',
  styleUrls: ['./servicos.findall.component.css']
})
export class ServicosfindAllComponent {



  formulario: any;
  tituloFormulario: string = '';

  listaservicos: Array<Servico> = new Array;
  listaservico: Array<Servico> = new Array;
  


  constructor(private servicoService : ServicosService, private router : Router){}
  

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
            setTimeout(()=> this.router.navigate(["/servicofindall"]), 3000);
            
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

