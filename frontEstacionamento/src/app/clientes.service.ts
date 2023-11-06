
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Cliente } from './Cliente';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class ClientesService {
  apiUrl = 'http://localhost:5000/Carro';
  constructor(private http: HttpClient) { }

  listar(): Observable<Cliente[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Cliente[]>(url);
  }

  buscar(cpf: string): Observable<Cliente> {
    const url = `${this.apiUrl}/buscar/${cpf}`;
    return this.http.get<Cliente>(url);
  }

  cadastrar(cliente: Cliente): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Cliente>(url, cliente, httpOptions);
  }

  alterar(cliente: Cliente): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<Cliente>(url, Cliente, httpOptions);
  }

  excluir(cpf: string): Observable<any> {
    const url = `${this.apiUrl}/excluir/${cpf}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
