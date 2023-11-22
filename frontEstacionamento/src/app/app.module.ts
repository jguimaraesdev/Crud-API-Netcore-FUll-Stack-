import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http'; 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule} from 'ngx-bootstrap/modal';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 
import { FormsModule } from '@angular/forms';


import { VeiculosService } from 'src/app/services/veiculos.service';
import { VeiculosComponent } from './pages/veiculos/veiculos.component';
import { ClientesService } from './services/clientes.service';
import { ClientesComponent } from './pages/clientes/clientes.component';
import { MarcasService } from './services/marcas.service';
import { MarcasComponent } from './pages/marcas/marcas.component';
import { ModelosService } from './services/modelos.service';
import { ModelosComponent } from './pages/modelos/modelos.component';
import { PeriodosService} from './services/periodos.service';
import { PeriodosComponent } from './pages/periodos/periodos.component';
import { TicketsService } from './services/tickets.service';
import { TicketsComponent } from './pages/tickets/tickets.component';
import { ServicosService } from './services/servicos.service';
import { ServicosComponent } from './pages/servicos/servicos.component';
import { NotaFiscalService } from './services/notas-fiscais.service';
import { NotasFiscaisComponent } from './pages/notas-fiscais/notas-fiscais.component';
import { HomeComponent } from './pages/home/home.component';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { ServicoextrasComponent } from './pages/servicoextras/servicoextras.component';
import { ServicosfindAllComponent } from './components/servicos.findall/servicos.findall.component';
import { ServicosEditComponent } from './components/servicos.edit/servicos.edit.component';
import { TicketsFindallComponent } from './components/tickets.findall/tickets.findall.component';
import { PagarTicketComponent } from './components/pagar.ticket/pagar.ticket.component';
import { TicketEditComponent } from './components/ticket.edit/ticket.edit.component';
import { ServicosPagarComponent } from './components/servicos.pagar/servicos.pagar.component';




@NgModule({
  declarations: [
    AppComponent,
    VeiculosComponent,
    ClientesComponent,
    MarcasComponent,
    ModelosComponent,
    PeriodosComponent,
    TicketsComponent,
    ServicosComponent,
    NotasFiscaisComponent,
    HomeComponent,
    ServicoextrasComponent,
    ServicosfindAllComponent,
    ServicosEditComponent,
    TicketsFindallComponent,
    PagarTicketComponent,
    TicketEditComponent,
    ServicosPagarComponent

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    BrowserAnimationsModule,
    FormsModule
  
  ],
  providers: [
    
    HttpClientModule, 
    VeiculosService,
    ClientesService,
    MarcasService,
    ModelosService,
    PeriodosService,
    TicketsService,
    ServicosService,
    NotaFiscalService
    
  ],
  bootstrap: [AppComponent]
  
})
export class AppModule { }
platformBrowserDynamic().bootstrapModule(AppModule);