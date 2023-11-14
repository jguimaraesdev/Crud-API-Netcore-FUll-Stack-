import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http'; 
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ReactiveFormsModule } from '@angular/forms';
import { ModalModule} from 'ngx-bootstrap/modal';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'; 


import { VeiculosService } from 'src/app/veiculos.service';
import { VeiculosComponent } from './components/veiculos/veiculos.component';
import { ClientesService } from './clientes.service';
import { ClientesComponent } from './components/clientes/clientes.component';
import { MarcasService } from './marcas.service';
import { MarcasComponent } from './components/marcas/marcas.component';
import { ModelosService } from './modelos.service';
import { ModelosComponent } from './components/modelos/modelos.component';
import { PeriodosService} from './periodos.service';
import { PeriodosComponent } from './components/periodos/periodos.component';
import { TicketsService } from './tickets.service';
import { TicketsComponent } from './components/tickets/tickets.component';
import { ServicosService } from './servicos.service';
import { ServicosComponent } from './components/servicos/servicos.component';
import { NotaFiscalService } from './notas-fiscais.service';
import { NotasFiscaisComponent } from './components/notas-fiscais/notas-fiscais.component';
import { HomeComponent } from './components/home/home.component';


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
    HomeComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule,
    ModalModule.forRoot(),
    BrowserAnimationsModule
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
