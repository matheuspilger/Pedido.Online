import { Component, OnInit } from '@angular/core';
import { OrderService } from '../../services/orders/order.service';
import { Order } from '../../models/orders/order.model';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-order-list',
  templateUrl: './order-list.component.html',
  styleUrls: ['./order-list.component.css']
})
export class OrderListComponent implements OnInit {

  searchActiveFilter: boolean = true;
  dataSource: Order[] = [];

  displayedColumns: string[] = ['isActive', 'name', 'price', 'edit', 'delete'];

  constructor(private orderService: OrderService,
    private router: Router) {
    this.getOrderList();
  }

  ngOnInit(): void {

  }

  updateOrder(orderId: string): void {
    this.router.navigate(['/order-form', { orderId: orderId }]);
  }

  deleteOrder(orderId: string): void {
    console.log(orderId);
    this.orderService.deleteOrder(orderId).subscribe(
      {
        next: (res) => {
          console.log(res);
          this.getOrderList(this.searchActiveFilter);
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
          alert(err.message);
        }
      }
    );
  }

  getOrderList(isActive: boolean = true): void {
    this.searchActiveFilter = isActive;
    this.orderService.getOrders(isActive).subscribe(
      {
        next: (res: Order[]) => {
          this.dataSource = res;
          console.log(this.dataSource);
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
          alert(err.message);
        }
      }
    );
  }
}