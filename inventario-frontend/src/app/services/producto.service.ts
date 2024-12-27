import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IProducto } from '../entidades/IProducto';

@Injectable({
  providedIn: 'root'
})
export class ProductoService {

  private apiUrl = environment.apiURL + '/Producto';
  constructor(private http: HttpClient) { }

  getProductos(): Observable<IProducto[]>{
    return this.http.get<IProducto[]>(this.apiUrl);
  }

  getProducto(idProducto: number): Observable<IProducto>{
      return this.http.get<IProducto>(`${this.apiUrl}/${idProducto}`);
  }

  createProducto(producto: IProducto): Observable<IProducto>{
    return this.http.post<IProducto>(this.apiUrl, producto);
  }

  updateProducto(producto: IProducto): Observable<void>{
    return this.http.put<void>(`${this.apiUrl}/${producto.idProducto}`, producto);
  }

  deleteProducto(idProducto: number): Observable<void>{
    return this.http.delete<void>(`${this.apiUrl}/${idProducto}`)
  }


}

