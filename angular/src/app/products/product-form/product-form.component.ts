import { Component, OnInit } from '@angular/core';
import { Product } from '../../models/products/product.model';
import { NgForm } from '@angular/forms';
import { ProductService } from '../../services/products/product.service';
import { HttpErrorResponse } from '@angular/common/http';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-product',
  templateUrl: './product-form.component.html',
  styleUrls: ['./product-form.component.css']
})
export class ProductComponent implements OnInit {

  isCreateProduct: boolean = true;
  product: any;

  constructor(private productService: ProductService,
    private router: Router,
    private activatedRoute: ActivatedRoute) {

  }

  ngOnInit(): void {

    this.product = this.activatedRoute.snapshot.data['product'];

    if (this.product && this.product.id != '') {
      this.isCreateProduct = false;
    } else {
      this.isCreateProduct = true;
      this.product.isActive = true;
    }

    console.log(this.product);
  }

  saveProduct(productForm: NgForm): void {

    if (this.isCreateProduct) {
      this.productService.saveProduct(this.product).subscribe(
        {
          next: (res: Product) => {
            console.log(res);
            productForm.reset();
            this.router.navigate(["/product-list"]);
          },
          error: (err: HttpErrorResponse) => {
            console.log(err);
            alert(err.message);
          }
        }
      );
    } else {
      this.productService.updateProduct(this.product).subscribe(
        {
          next: (res: Product) => {
            this.router.navigate(["/product-list"]);
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
    this.product.isActive = $event.checked;
  }
}
