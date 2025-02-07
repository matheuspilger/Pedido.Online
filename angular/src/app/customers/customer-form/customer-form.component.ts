import { Component, OnInit } from '@angular/core';
import { Customer } from '../../models/customers/customer.model';
import { NgForm } from '@angular/forms';
import { CustomerService } from '../../services/customers/customer.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-customer',
  templateUrl: './customer-form.component.html',
  styleUrls: ['./customer-form.component.css']
})
export class CustomerComponent implements OnInit {

  isCreateCustomer: boolean = true;
  customer: any;

  constructor(private customerService: CustomerService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {

  }

  ngOnInit(): void {

    this.customer = this.activatedRoute.snapshot.data['customer'];

    if (this.customer && this.customer.id != '') {
      this.isCreateCustomer = false;
    } else {
      this.isCreateCustomer = true;
      this.customer.isActive = true;
    }

    console.log(this.customer);
  }

  saveCustomer(customerForm: NgForm): void {

    if (this.isCreateCustomer) {
      this.customerService.saveCustomer(this.customer).subscribe(
        {
          next: (res: Customer) => {
            console.log(res);
            customerForm.reset();
            this.router.navigate(["/customer-list"]);
          },
          error: (err: HttpErrorResponse) => {
            console.log(err);
            alert(err.message);
          }
        }
      );
    } else {
      this.customerService.updateCustomer(this.customer).subscribe(
        {
          next: (res: Customer) => {
            this.router.navigate(["/customer-list"]);
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
    this.customer.isActive = $event.checked;
  }
}
