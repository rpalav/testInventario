import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './components/layout/layout.component';
import { LoginComponent } from './components/login/login.component';
import { LoteGestionComponent } from './components/lote/lote-gestion/lote-gestion.component';
import { LoteComponent } from './components/lote/lote.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { ProductoGestionComponent } from './components/producto/producto-gestion/producto-gestion.component';
import { ProductoComponent } from './components/producto/producto.component';
import { LoginGuard } from './login.guard';

const routes: Routes = [
  {
    path:'',
    component: LoginComponent
  },
  {
    path:'login',
    component: LoginComponent
  },
  {
    path:'producto',
    component: ProductoComponent,
    canActivate:[LoginGuard]
  },
  {
    path:'productoGestion',
    component: ProductoGestionComponent,
    canActivate:[LoginGuard]
  },
  {
    path:'productoGestion/:id',
    component: ProductoGestionComponent,
    canActivate:[LoginGuard]
  },
  {
    path:'lote',
    component: LoteComponent,
    canActivate:[LoginGuard]
  },
  {
    path:'lote/gestion/:id',
    component: LoteGestionComponent,
    canActivate:[LoginGuard]
  },
  {
    path:'main',
    component: LayoutComponent,
    canActivate:[LoginGuard]
  },
  { path: '**', component: PageNotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
