import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { NotaFiscal } from '../models/NotaFiscal';
import { environment } from 'src/environments/environment.development';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})

export class NotaFiscalService {

  private apiUrl = `${environment.ApiUrl}/Nota`;
  
  constructor(private http: HttpClient) { }

  listar(): Observable<NotaFiscal[]> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<NotaFiscal[]>(url);
  }

  buscar(numeroNota : number): Observable<NotaFiscal> {
    const url = `${this.apiUrl}/buscar/${numeroNota}`;
    return this.http.get<NotaFiscal>(url);
  }

  cadastrar(notaFiscal: NotaFiscal): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<any>(url, notaFiscal, httpOptions);
  }

  alterar(notaFiscal: NotaFiscal): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<any>(url, notaFiscal, httpOptions);
  }

  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<any>(url, httpOptions);
  }
}