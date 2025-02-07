import { ActivatedRouteSnapshot, ResolveFn, RouterStateSnapshot } from "@angular/router";
import { OrderService } from "../../services/orders/order.service";
import { inject } from "@angular/core";
import { Observable, of } from "rxjs";
import { Order } from "./order.model";

export const OrderResolver: ResolveFn<any> = 
    (route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot,
        orderService: OrderService = inject(OrderService)) :Observable<Order> => {


            const orderId = route.paramMap.get("orderId");

            if(orderId) {
                return orderService.getOrder(orderId);
            } else {
                const order: Order = {
                    id: '',
                    isActive: true,
                    customerId: '',
                    orderDate: Date.now(),
                    itens: [],
                    status: 1,
                    totalAmount: 0
                }

                return of(order);
            }
        }