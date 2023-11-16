import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Ticket } from '../models/Ticket';



const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})

export class TicketsService {
  private apiUrl = 'http://localhost:5000/Ticket';
  constructor(private http: HttpClient) { }

  listar(): Observable<Ticket[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Ticket[]>(url);
  }

  buscar(id : number): Observable<Ticket> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Ticket>(url);
  }

  cadastrar(ticket: Ticket): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<any>(url, ticket, httpOptions);
  }

  alterar(ticket: Ticket): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<any>(url, ticket, httpOptions);
  }

  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<any>(url, httpOptions);
  }
}