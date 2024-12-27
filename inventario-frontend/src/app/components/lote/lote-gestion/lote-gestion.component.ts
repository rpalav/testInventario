import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ICatalogo } from 'src/app/entidades/ICatalogo';
import { ILoteProducto } from 'src/app/entidades/ILoteProducto';
import { IProducto } from 'src/app/entidades/IProducto';
import { CatalogoService } from 'src/app/services/catalogo.service';
import { LoteProductoService } from 'src/app/services/lote-producto.service';
import { MensajesService } from 'src/app/services/mensajes.service';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-lote-gestion',
  templateUrl: './lote-gestion.component.html',
  styleUrls: ['./lote-gestion.component.sass']
})
export class LoteGestionComponent implements OnInit {

  estadosLote: ICatalogo[] = [];
  productos: IProducto[] = [];
  public loteForm: FormGroup;

  constructor(private fb: FormBuilder,
    private loteProductoService: LoteProductoService,
    private _catalogoService: CatalogoService,
    private _productoService: ProductoService,
    private _mensajesService: MensajesService,
    private route: ActivatedRoute) {

    this.loteForm = this.fb.group({
      idLote: [0, [Validators.required]],
      codigoLote: ['', [Validators.required, Validators.maxLength(50)]],
      precio: [0, [Validators.required, Validators.min(0)]],
      stock: [0, [Validators.required, Validators.min(0)]],
      idEstadoLote: [0, [Validators.required]],
      idProducto: [0, [Validators.required]],
      fechaFabricacion: [, ],
      fechaVencimiento: [, ]
    });
   }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id && parseInt(id) > 0) {
      this.loadLote(+id);
    }
    this.cargarCatalogos();
  }


  private cargarCatalogos():void{
    this._catalogoService.GetCatalogoEstadoProducto().subscribe(resp => {
      this.estadosLote = resp;
    })

    this._productoService.getProductos().subscribe(resp => {
      this.productos = resp;
    });
  }

  loadLote(id: number): void {
    this.loteProductoService.getLoteProducto(id).subscribe((response) => {
      this.loteForm.patchValue(response)
    });
  }

  onSubmit(): void {
    if (this.loteForm.valid) {
      const loteProducto = this.loteForm.value as ILoteProducto;
      if(loteProducto.idLote > 0) {
        this.loteProductoService.updateLoteProducto(loteProducto).subscribe((response) => {
          this._mensajesService.Correcto('Gestion de lotes', 'Informacion actulizada correctamente');
        });
      } else {
        this.loteProductoService.createLoteProducto(loteProducto).subscribe((response) => {
          this._mensajesService.Correcto('Gestion de lotes', 'Informacion guardada correctamente');
        });
      }
    }
  }

  resetForm(): void {
    this.loteForm.reset();
  }
}
