import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IProducto } from '../entidades/IProducto';
import { ICatalogo } from '../entidades/ICatalogo';

@Injectable({
  providedIn: 'root'
})
export class CatalogoService {

  private apiUrl = environment.apiURL;
  constructor(private http: HttpClient) { }

  GetCatalogoEstadoLote(): Observable<ICatalogo[]>{
      return this.http.get<ICatalogo[]>(`${this.apiUrl}/Catalogo/GetCatalogoEstadoLote`);
  }

  GetCatalogoEstadoProducto(): Observable<ICatalogo[]>{
    return this.http.get<ICatalogo[]>(`${this.apiUrl}/Catalogo/GetCatalogoEstadoProducto`);
  }

}

