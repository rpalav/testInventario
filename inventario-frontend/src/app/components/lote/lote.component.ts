import { Component, OnInit } from '@angular/core';
import { ILoteProducto } from 'src/app/entidades/ILoteProducto';
import { PaginacionRequest, PaginacionResponse } from 'src/app/entidades/IPaginacion';
import { LoteProductoService } from 'src/app/services/lote-producto.service';
import { MensajesService } from 'src/app/services/mensajes.service';

@Component({
  selector: 'app-lote',
  templateUrl: './lote.component.html',
  styleUrls: ['./lote.component.sass']
})
export class LoteComponent implements OnInit {
  lotesProductos: any[] = [];
  page: number = 1;
  pageSize: number = 5;
  totalItems: number = 0;
  sortField: string = 'IdLote';
  sortDirection: 'asc' | 'desc' = 'asc';
  totalPages: number = 1;
  searchTerm: string = '';

  constructor(private loteProductoService: LoteProductoService,
    private _mensajesService: MensajesService) {}

  ngOnInit(): void {
    this.loadLotes();
  }

  loadLotes(): void {
    this.loteProductoService
      .filtroLoteProductos(this.page, this.pageSize, this.sortField, this.sortDirection,
        this.searchTerm)
      .subscribe((response) => {
        this.lotesProductos = response.items;
        this.totalItems = response.totalCount;
        this.totalPages = Math.ceil(this.totalItems / this.pageSize);
      });
  }

  changePage(newPage: number): void {
    this.page = newPage;
    this.loadLotes();
  }

  public sortBy(field: string): void {
    if (this.sortField === field) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortField = field;
      this.sortDirection = 'asc';
    }
    this.loadLotes();
  }

  onSearch(): void {
    this.page = 1;
    this.loadLotes();
  }


  deleteLote(id: number): void {
    if (confirm('¿Estás seguro de que deseas eliminar este lote?')) {
      this.loteProductoService.deleteLoteProducto(id).subscribe(() => {
        this._mensajesService.Correcto('Gestion de lotes', 'Lote eliminado correctamente');
        this.loadLotes();
      });
    }
  }
}
