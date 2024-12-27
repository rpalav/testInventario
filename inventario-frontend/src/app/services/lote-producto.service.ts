import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ILoteProducto } from '../entidades/ILoteProducto';
import { PaginacionRequest, PaginacionResponse } from '../entidades/IPaginacion';

@Injectable({
  providedIn: 'root'
})
export class LoteProductoService {

  private apiUrl = environment.apiURL + '/LoteProducto';
  constructor(private http: HttpClient) { }

  getLoteProductos(): Observable<ILoteProducto[]>{
    return this.http.get<ILoteProducto[]>(this.apiUrl);
  }

  getLoteProducto(idLoteProducto: number): Observable<ILoteProducto>{
      return this.http.get<ILoteProducto>(`${this.apiUrl}/${idLoteProducto}`);
  }

  createLoteProducto(loteProducto: ILoteProducto): Observable<ILoteProducto>{
    return this.http.post<ILoteProducto>(this.apiUrl, loteProducto);
  }

  updateLoteProducto(loteProducto: ILoteProducto): Observable<void>{
    return this.http.put<void>(`${this.apiUrl}/${loteProducto.idLote}`, loteProducto);
  }

  deleteLoteProducto(idLoteProducto: number): Observable<void>{
    return this.http.delete<void>(`${this.apiUrl}/${idLoteProducto}`)
  }

  filtroLoteProductos(
    page: number,
    pageSize: number,
    sortField: string,
    sortDirection: string,
    searchTerm: string
  ): Observable<any> {
    const params = {
      page: page.toString(),
      pageSize: pageSize.toString(),
      filter:searchTerm,
      sortField,
      sortDirection
    };
    return this.http.post<any>(`${this.apiUrl}/GetLotesProductos`, params);
  }
}

