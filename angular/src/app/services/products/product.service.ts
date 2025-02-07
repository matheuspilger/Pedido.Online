import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Product } from '../../models/products/product.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpClient: HttpClient) { }

  api = "https://localhost:7054/api/product"

  public saveProduct(product: Product): Observable<Product> {
    return this.httpClient.post<Product>(`${this.api}/insert`, product);
  }

  public getProducts(isActive: boolean): Observable<Product[]> {
      return this.httpClient.get<Product[]>(`${this.api}/getall?isActive=${isActive}`);
  }

  public deleteProduct(productId: string) {
    return this.httpClient.delete(`${this.api}/delete?id=${productId}`);
  }

  public getProduct(productId: string) {
    return this.httpClient.get<Product>(`${this.api}/get?id=${productId}`);
  }

  public updateProduct(product: Product) {
    console.log(product);
    return this.httpClient.put<Product>(`${this.api}/update`, product);
  }
}