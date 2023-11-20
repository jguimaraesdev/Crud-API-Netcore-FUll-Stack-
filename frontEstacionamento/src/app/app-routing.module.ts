import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VeiculosComponent } from './pages/veiculos/veiculos.component';
import { ClientesComponent } from './pages/clientes/clientes.component';
import { MarcasComponent } from './pages/marcas/marcas.component';
import { ModelosComponent } from './pages/modelos/modelos.component';
import { PeriodosComponent } from './pages/periodos/periodos.component';
import { TicketsComponent } from './pages/tickets/tickets.component';
import { ServicosComponent } from './pages/servicos/servicos.component';
import { NotasFiscaisComponent } from './pages/notas-fiscais/notas-fiscais.component';
import { HomeComponent } from './pages/home/home.component';
import { ServicoextrasComponent } from './pages/servicoextras/servicoextras.component';
import { ServicosfindAllComponent } from './components/servicos.findall/servicos.findall.component';
import { ServicosEditComponent } from './components/servicos.edit/servicos.edit.component';
import { TicketsFindallComponent } from './components/tickets.findall/tickets.findall.component';
import { PagarTicketComponent } from './components/pagar.ticket/pagar.ticket.component';
import { TicketEditComponent } from './components/ticket.edit/ticket.edit.component';

const routes: Routes = [
  
  {path: 'veiculo', component: VeiculosComponent},
  {path: 'cliente', component: ClientesComponent},
  {path: 'marcas', component: MarcasComponent},
  {path: 'modelo', component: ModelosComponent},
  {path: 'periodo', component: PeriodosComponent},
  {path: 'ticket', component: TicketsComponent},
  {path: 'servico', component: ServicosComponent},
  {path: 'notafiscal', component: NotasFiscaisComponent},
  {path: 'home', component: HomeComponent},
  {path: 'servicoextras', component: ServicoextrasComponent},
  {path: 'servicosfindall', component: ServicosfindAllComponent},
  {path:'servicosedit', component: ServicosEditComponent},
  {path:'ticketsfindall', component: TicketsFindallComponent},
  {path: 'pagarticket', component:PagarTicketComponent},
  {path: 'ticketedit', component: TicketEditComponent}
]
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
