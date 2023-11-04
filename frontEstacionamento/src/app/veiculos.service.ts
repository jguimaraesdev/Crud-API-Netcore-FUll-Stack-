import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Veiculo } from './Veiculo';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class VeiculosService {
  apiUrl = 'http://localhost:5000/Carro';
  constructor(private http: HttpClient) { }

  listar(): Observable<Veiculo[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Veiculo[]>(url);
  }

  buscar(placa: string): Observable<Veiculo> {
    const url = `${this.apiUrl}/buscar/${placa}`;
    return this.http.get<Veiculo>(url);
  }

  cadastrar(Veiculo: Veiculo): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Veiculo>(url, Veiculo, httpOptions);
  }

  atualizar(Veiculo: Veiculo): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Veiculo>(url, Veiculo, httpOptions);
  }

  excluir(placa: string): Observable<any> {
    const url = `${this.apiUrl}/excluir/${placa}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
