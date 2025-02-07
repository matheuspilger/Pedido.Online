import { ActivatedRouteSnapshot, ResolveFn, RouterStateSnapshot } from "@angular/router";
import { ProductService } from "../../services/products/product.service";
import { inject } from "@angular/core";
import { Observable, of } from "rxjs";
import { Product } from "./product.model";

export const ProductResolver: ResolveFn<any> = 
    (route: ActivatedRouteSnapshot,
        state: RouterStateSnapshot,
        productService: ProductService = inject(ProductService)) :Observable<Product> => {


            const productId = route.paramMap.get("productId");

            if(productId) {
                return productService.getProduct(productId);
            } else {
                const product: Product = {
                    id: '',
                    isActive: true,
                    name: '',
                    price: 0.0
                }

                return of(product);
            }
        }