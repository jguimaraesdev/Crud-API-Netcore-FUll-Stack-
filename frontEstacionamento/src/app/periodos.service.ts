import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Periodo } from './Periodo';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})

export class PeriodosService {
  apiUrl = 'http://localhost:5000/Modelo';
  constructor(private http: HttpClient) { }

  listar(): Observable<Periodo[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Periodo[]>(url);
  }

  buscar(id : number): Observable<Periodo> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Periodo>(url);
  }

  cadastrar(periodo: Periodo): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<any>(url, periodo, httpOptions);
  }

  alterar(periodo: Periodo): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<any>(url, periodo, httpOptions);
  }

  update(placa: String): Observable<any> {
    const url = `${this.apiUrl}/alterar/saida`;
    const data = { placa: placa};
    return this.http.put<any>(url, data, httpOptions);
  }

  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<any>(url, httpOptions);
  }
}