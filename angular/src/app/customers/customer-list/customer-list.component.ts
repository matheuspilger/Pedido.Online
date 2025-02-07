import { Component, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customers/customer.service';
import { Customer } from '../../models/customers/customer.model';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-customer-list',
  templateUrl: './customer-list.component.html',
  styleUrls: ['./customer-list.component.css']
})
export class CustomerListComponent implements OnInit {

  searchActiveFilter: boolean = true;
  dataSource: Customer[] = [];

  displayedColumns: string[] = ['isActive', 'name', 'email', 'phone', 'edit', 'delete'];

  constructor(private customerService: CustomerService,
    private router: Router) {
    this.getCustomerList();
  }

  ngOnInit(): void {

  }

  updateCustomer(customerId: string): void {
    this.router.navigate(['/customer-form', { customerId: customerId }]);
  }

  deleteCustomer(customerId: string): void {
    console.log(customerId);
    this.customerService.deleteCustomer(customerId).subscribe(
      {
        next: (res) => {
          console.log(res);
          this.getCustomerList(this.searchActiveFilter);
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
          alert(err.message);
        }
      }
    );
  }

  getCustomerList(isActive: boolean = true): void {
    this.searchActiveFilter = isActive;
    this.customerService.getCustomers(isActive).subscribe(
      {
        next: (res: Customer[]) => {
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