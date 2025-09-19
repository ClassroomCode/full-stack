import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export class Product {
  productID!: number
  productName!: string
  unitPrice!: number
}

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

  baseUrl = "http://localhost:5000";

  constructor(private http: HttpClient) { }

  getProducts(): Observable<Product[]> {
    return this.http.get<Product[]>(`{this.baseUrl}/products`);
  }

  getProduct( id: number ): Observable<Product> {
    return this.http.get<Product>(this.baseUrl + `/product/${id}` );
  }

  deleteBook( id: number ): Observable<any> {
    // TODO: need to add auth header
    return this.http.delete<Product>(this.baseUrl + `/product/${id}` );
  }

  addBook( product: Product ): Observable<any> {
    return this.http.post<Product>(this.baseUrl + '/product', product);
  }

  updateBook( product: Product ): Observable<any> {
    return this.http.put<Product>(this.baseUrl + `/product/${product.productID}`, product);
  }
}
