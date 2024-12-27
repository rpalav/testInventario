import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ErrorInterceptor } from './interceptores/error.interceptor';
import { LoadingInterceptor } from './interceptores/loading.interceptor';
import { SeguridadInterceptorService } from './interceptores/seguridad-interceptor.service';
import { LoginComponent } from './components/login/login.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from "@angular/common/http";
import { MenuComponent } from './components/menu/menu.component';
import { LayoutComponent } from './components/layout/layout.component';
import { ProductoComponent } from './components/producto/producto.component';
import { ProductoGestionComponent } from './components/producto/producto-gestion/producto-gestion.component';
import { LoteComponent } from './components/lote/lote.component';
import { NgxDatatableModule } from '@swimlane/ngx-datatable';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap'

import swal from 'sweetalert2';
import { MensajesService } from './services/mensajes.service';
import { LoteGestionComponent } from './components/lote/lote-gestion/lote-gestion.component';
import { SpinnerComponent } from './components/spinner/spinner.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    MenuComponent,
    LayoutComponent,
    ProductoComponent,
    ProductoGestionComponent,
    LoteComponent,
    LoteGestionComponent,
    SpinnerComponent,
    PageNotFoundComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,

    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,

    NgxDatatableModule,

    NgbModule
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor  , multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: SeguridadInterceptorService  , multi: true }],
  bootstrap: [AppComponent]
})
export class AppModule { }
