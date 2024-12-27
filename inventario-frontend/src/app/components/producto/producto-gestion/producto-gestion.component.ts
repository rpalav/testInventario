import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ICatalogo } from 'src/app/entidades/ICatalogo';
import { IProducto } from 'src/app/entidades/IProducto';
import { CatalogoService } from 'src/app/services/catalogo.service';
import { MensajesService } from 'src/app/services/mensajes.service';
import { ProductoService } from 'src/app/services/producto.service';

@Component({
  selector: 'app-producto-gestion',
  templateUrl: './producto-gestion.component.html',
  styleUrls: ['./producto-gestion.component.sass']
})
export class ProductoGestionComponent implements OnInit {


  productoForm: FormGroup;
  previewImage: string | null = null;
  estadosProducto: ICatalogo[] = [];

  constructor(private fb: FormBuilder,
              private _catalogoService: CatalogoService,
              private _mensajesService: MensajesService,
              private route: ActivatedRoute,
              private _productoService: ProductoService) {
    this.productoForm = this.fb.group({
      idProducto: [0, [Validators.required]],
      idEstadoProducto: [null, [Validators.required]],
      nombre: ['', [Validators.required, Validators.maxLength(100)]],
      descripcion: ['', [Validators.maxLength(500)]],
      imagen: ['']
    });

  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id && parseInt(id) > 0) {
      this.loadProducto(+id);
    }
    this.cargarCatalogo();
  }

  loadProducto(id: number): void {
    this._productoService.getProducto(id).subscribe((response) => {
      this.productoForm.patchValue(response)
    });
  }

  private cargarCatalogo():void{
    this._catalogoService.GetCatalogoEstadoProducto().subscribe(resp => {
      this.estadosProducto = resp;
    })
  }

  onImageSelected(event: Event): void {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files[0]) {
      const file = input.files[0];
      const reader = new FileReader();
      reader.onload = () => {
        this.previewImage = reader.result as string;
      };
      reader.readAsDataURL(file);
    }
  }

  onSubmit(): void {
    if (this.productoForm.valid) {
      const producto = this.productoForm.value as IProducto;
      if (producto.idProducto === 0) {
        this._productoService.createProducto(producto).subscribe(resp => {
          this._mensajesService.Correcto('Producto', 'Producto almacenado correctamente');
        })
      } else {
        this._productoService.updateProducto(producto).subscribe(resp => {
            this._mensajesService.Correcto('Producto', 'Producto actualizado correctamente');
        })
      }
      console.log('Producto guardado:', producto);
    }
  }

  resetForm(): void {
    this.productoForm.reset();
    this.previewImage = null;
  }

}
