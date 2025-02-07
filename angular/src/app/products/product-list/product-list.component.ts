import { Component, OnInit } from '@angular/core';
import { ProductService } from '../../services/products/product.service';
import { Product } from '../../models/products/product.model';
import { HttpErrorResponse } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  searchActiveFilter: boolean = true;
  dataSource: Product[] = [];

  displayedColumns: string[] = ['isActive', 'name', 'price', 'edit', 'delete'];

  constructor(private productService: ProductService,
    private router: Router) {
    this.getProductList();
  }

  ngOnInit(): void {

  }

  updateProduct(productId: string): void {
    this.router.navigate(['/product-form', { productId: productId }]);
  }

  deleteProduct(productId: string): void {
    console.log(productId);
    this.productService.deleteProduct(productId).subscribe(
      {
        next: (res) => {
          console.log(res);
          this.getProductList(this.searchActiveFilter);
        },
        error: (err: HttpErrorResponse) => {
          console.log(err);
          alert(err.message);
        }
      }
    );
  }

  getProductList(isActive: boolean = true): void {
    this.searchActiveFilter = isActive;
    this.productService.getProducts(isActive).subscribe(
      {
        next: (res: Product[]) => {
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