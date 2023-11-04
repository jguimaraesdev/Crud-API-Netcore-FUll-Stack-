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


@NgModule({
  declarations: [
    AppComponent,
    VeiculosComponent
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
    VeiculosService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
