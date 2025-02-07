import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Customer } from '../../models/customers/customer.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {

  constructor(private httpClient: HttpClient) { }

  api = "https://localhost:7054/api/customer"

  public saveCustomer(customer: Customer): Observable<Customer> {
    return this.httpClient.post<Customer>(`${this.api}/insert`, customer);
  }

  public getCustomers(isActive: boolean): Observable<Customer[]> {
      return this.httpClient.get<Customer[]>(`${this.api}/getall?isActive=${isActive}`);
  }

  public deleteCustomer(customerId: string) {
    return this.httpClient.delete(`${this.api}/delete?id=${customerId}`);
  }

  public getCustomer(customerId: string) {
    return this.httpClient.get<Customer>(`${this.api}/get?id=${customerId}`);
  }

  public updateCustomer(customer: Customer) {
    console.log(customer);
    return this.httpClient.put<Customer>(`${this.api}/update`, customer);
  }
}