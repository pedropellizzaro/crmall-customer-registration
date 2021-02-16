import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CustomerComponent } from './components/customer/customer.component';
import { FormComponent } from './components/form/form.component';
import { CustomerResolverGuard } from './components/guards/customer-resolver.guard';

const routes: Routes = [
  { path: '', redirectTo: 'clientes', pathMatch: 'full' },
  { path: 'clientes', component: CustomerComponent },
  {
    path: 'clientes/cadastro',
    component: FormComponent,
    resolve: {
      customer: CustomerResolverGuard,
    },
  },
  {
    path: 'clientes/editar/:id',
    component: FormComponent,
    resolve: {
      customer: CustomerResolverGuard,
    },
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
