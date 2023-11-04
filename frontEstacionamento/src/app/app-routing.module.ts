import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VeiculosComponent } from './components/veiculos/veiculos.component';

const routes: Routes = [
  
  {path: 'veiculos', component: VeiculosComponent},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
