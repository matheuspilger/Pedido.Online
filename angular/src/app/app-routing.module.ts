import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HeaderComponent } from './header/header.component';
import { HomeComponent } from './home/home.component';

import { CustomerComponent } from './customers/customer-form/customer-form.component';
import { CustomerListComponent } from './customers/customer-list/customer-list.component';
import { CustomerResolver } from './models/customers/customer-resolver';

import { ProductComponent } from './products/product-form/product-form.component';
import { ProductListComponent } from './products/product-list/product-list.component';
import { ProductResolver } from './models/products/product-resolver';

import { OrderComponent } from './orders/order-form/order-form.component';
import { OrderListComponent } from './orders/order-list/order-list.component';
import { OrderResolver } from './models/orders/order-resolver';

const routes: Routes = [
  {path: 'header', component: HeaderComponent},
  {path: 'customer-form', component: CustomerComponent, resolve: {customer: CustomerResolver} },
  {path: 'customer-list', component: CustomerListComponent},
  {path: 'product-form', component: ProductComponent, resolve: {product: ProductResolver} },
  {path: 'product-list', component: ProductListComponent},
  {path: 'order-form', component: OrderComponent, resolve: {order: OrderResolver} },
  {path: 'order-list', component: OrderListComponent},
  {path: '', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
