import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Carro } from './Carro';
const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})
export class CarrosService {
  apiUrl = 'http://localhost:5000/Carro';
  constructor(private http: HttpClient) { }

  listar(): Observable<Carro[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Carro[]>(url);
  }

  buscar(placa: string): Observable<Carro> {
    const url = `${this.apiUrl}/buscar/${placa}`;
    return this.http.get<Carro>(url);
  }

  cadastrar(carro: Carro): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<Carro>(url, carro, httpOptions);
  }

  atualizar(carro: Carro): Observable<any> {
    const url = `${this.apiUrl}/atualizar`;
    return this.http.put<Carro>(url, carro, httpOptions);
  }

  excluir(placa: string): Observable<any> {
    const url = `${this.apiUrl}/excluir/${placa}`;
    return this.http.delete<string>(url, httpOptions);
  }
}
