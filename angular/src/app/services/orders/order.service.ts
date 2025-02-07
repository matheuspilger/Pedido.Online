import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Order } from '../../models/orders/order.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private httpClient: HttpClient) { }

  api = "https://localhost:7054/api/order"

  public saveOrder(order: Order): Observable<Order> {
    return this.httpClient.post<Order>(`${this.api}/insert`, order);
  }

  public getOrders(isActive: boolean): Observable<Order[]> {
      return this.httpClient.get<Order[]>(`${this.api}/getall?isActive=${isActive}`);
  }

  public deleteOrder(orderId: string) {
    return this.httpClient.delete(`${this.api}/delete?id=${orderId}`);
  }

  public getOrder(orderId: string) {
    return this.httpClient.get<Order>(`${this.api}/get?id=${orderId}`);
  }

  public updateOrder(order: Order) {
    console.log(order);
    return this.httpClient.put<Order>(`${this.api}/update`, order);
  }
}