import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VeiculosComponent } from './components/veiculos/veiculos.component';
import { ClientesComponent } from './components/clientes/clientes.component';
import { MarcasComponent } from './components/marcas/marcas.component';
import { ModelosComponent } from './components/modelos/modelos.component';
import { PeriodosComponent } from './components/periodos/periodos.component';
import { TicketsComponent } from './components/tickets/tickets.component';
import { ServicosComponent } from './components/servicos/servicos.component';
import { NotasFiscaisComponent } from './components/notas-fiscais/notas-fiscais.component';
import { HomeComponent } from './components/home/home.component';

const routes: Routes = [
  
  {path: 'veiculo', component: VeiculosComponent},
  {path: 'cliente', component: ClientesComponent},
  {path: 'marcas', component: MarcasComponent},
  {path: 'modelo', component: ModelosComponent},
  {path: 'periodo', component: PeriodosComponent},
  {path: 'ticket', component: TicketsComponent},
  {path: 'servico', component: ServicosComponent},
  {path: 'notafiscal', component: NotasFiscaisComponent},
  {path: 'home', component: HomeComponent}
]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
