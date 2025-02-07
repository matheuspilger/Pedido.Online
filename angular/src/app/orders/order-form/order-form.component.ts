import { Component, OnInit } from '@angular/core';
import { Order } from '../../models/orders/order.model';
import { NgForm } from '@angular/forms';
import { OrderService } from '../../services/orders/order.service';
import { ProductService } from '../../services/products/product.service';
import { CustomerService } from '../../services/customers/customer.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';
import { Customer } from 'src/app/models/customers/customer.model';
import { Product } from 'src/app/models/products/product.model';

@Component({
  selector: 'app-order',
  templateUrl: './order-form.component.html',
  styleUrls: ['./order-form.component.css']
})
export class OrderComponent implements OnInit {

  isCreateOrder: boolean = true;
  order: any;

  customersDataSource: Customer[] = [];
  productsDataSource: Product[] = [];

  constructor(private orderService: OrderService,
    private productService: ProductService,
    private customerService: CustomerService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {
      this.getCustomers();
      this.getProducts();
  }

  ngOnInit(): void {

    this.order = this.activatedRoute.snapshot.data['order'];

    if (this.order && this.order.id != '') {
      this.isCreateOrder = false;
    } else {
      this.isCreateOrder = true;
      this.order.isActive = true;
    }

    console.log(this.order);
  }

  getCustomers(): void {
    this.customerService.getCustomers(true).subscribe(
      {
        next: (res: Customer[]) => {
          this.customersDataSource = res;
          console.log(this.customersDataSource);
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
          alert(err.message);
        }
      }
    );
  }

  getProducts(): void {
    this.productService.getProducts(true).subscribe(
      {
        next: (res: Product[]) => {
          this.productsDataSource = res;
          console.log(this.productsDataSource);
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
          alert(err.message);
        }
      }
    );
  }

  saveOrder(orderForm: NgForm): void {

    if (this.isCreateOrder) {
      this.orderService.saveOrder(this.order).subscribe(
        {
          next: (res: Order) => {
            console.log(res);
            orderForm.reset();
            this.router.navigate(["/order-list"]);
          },
          error: (err: HttpErrorResponse) => {
            console.log(err);
            alert(err.message);
          }
        }
      );
    } else {
      this.orderService.updateOrder(this.order).subscribe(
        {
          next: (res: Order) => {
            this.router.navigate(["/order-list"]);
          },
          error: (err: HttpErrorResponse) => {
            console.log(err);
            alert(err.error);
          }
        }
      );
    }
  }

  onIsAtive($event: any): void {
    this.order.isActive = $event.checked;
  }
  
}
