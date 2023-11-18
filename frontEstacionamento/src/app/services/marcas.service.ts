import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Marca } from '../models/Marca';
import { environment } from 'src/environments/environment.development';

const httpOptions = {
  headers: new HttpHeaders({
    'Content-Type' : 'application/json'
  })
}

@Injectable({
  providedIn: 'root'
})

export class MarcasService {
  private apiUrl = `${environment.ApiUrl}/Marca`;

  constructor(private http: HttpClient) { }


  listar(): Observable<Array<Marca>> {
    const url = `${this.apiUrl}/listar`;
    return this.http.get<Array<Marca>>(url);
  }

  buscar(id: number): Observable<Marca> {
    const url = `${this.apiUrl}/buscar/${id}`;
    return this.http.get<Marca>(url);
  }

  cadastrar(marca: Marca): Observable<any> {
    const url = `${this.apiUrl}/cadastrar`;
    return this.http.post<any>(url, marca, httpOptions);
  }

  alterar(marca: Marca): Observable<any> {
    const url = `${this.apiUrl}/alterar`;
    return this.http.put<any>(url, marca, httpOptions);
  }

  excluir(id: number): Observable<any> {
    const url = `${this.apiUrl}/excluir/${id}`;
    return this.http.delete<any>(url, httpOptions);
  }
}
