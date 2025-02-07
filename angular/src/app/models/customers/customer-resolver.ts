import { ActivatedRouteSnapshot, ResolveFn, RouterStateSnapshot } from "@angular/router";
import { CustomerService } from "../../services/customers/customer.service";
import { inject } from "@angular/core";
import { Observable, of } from "rxjs";
import { Customer } from "./customer.model";

export const CustomerResolver: ResolveFn<any> = 
    (route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot,
        customerService: CustomerService = inject(CustomerService)) :Observable<Customer> => {


            const customerId = route.paramMap.get("customerId");

            if(customerId) {
                // make api call and get data for given customer id
                return customerService.getCustomer(customerId);
            } else {
                // create and return empty customer details

                const customer: Customer = {
                    id: '',
                    isActive: true,
                    name: '',
                    email: '',
                    phone: ''
                }

                return of(customer);
            }
        }