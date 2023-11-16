import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Servico } from '../models/Servico';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})

export class ServicosService {
  private apiUrl = 'http://localhost:5000/Servico';
  constructor(private http: HttpClient) { }

  listar(): Observable<Servico[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Servico[]>(url);
  }

  buscar(id : number): Observable<Servico> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Servico>(url);
  }

  cadastrar(servico: Servico): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<any>(url, servico, httpOptions);
  }

  update(id: number, valor: number): Observable<any> {
    const url = `${this.apiUrl}/update/ValorServico`;
    const data = { id: id, valor: valor };
    return this.http.put<any>(url, data, httpOptions);
  }

  alterar(servico: Servico): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<any>(url, servico, httpOptions);
  }


  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<any>(url, httpOptions);
  }
}